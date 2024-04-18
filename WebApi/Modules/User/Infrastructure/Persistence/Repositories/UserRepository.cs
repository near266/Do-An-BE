using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.Contracts.Persistence;
using WebApi.Application.Exceptions;
using WebApi.Configurations;
using WebApi.Modules.Constants;
using WebApi.Modules.Dtos;
using WebApi.Modules.User.Domain.Entites;
using WebApi.Shared.Constants;
using WebApi.Wrappers;
using WebApi.Wrappers.DTOS.EmailDtos;
using static WebApi.Modules.Dtos.ServiceResponses;


namespace WebApi.Modules.User.Infrastructure.Persistence.Repositories
{
    public class UserRepository(UserManager<UserIdentity> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config,
         JWTSettings jwtSettings,
         SignInManager<UserIdentity> signInManager
        ) : IUserRepository
    {
        public async Task<ServiceResponses.GeneralResponse> CreateAccount(UserDtos userDTO)
        {
            if (userDTO is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new UserIdentity()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                UserName = userDTO.UserName,
                
            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User registered already");

            var createUser = await userManager.CreateAsync(newUser!, userDTO.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error occured.. please try again");

            //Assign Default Role : Admin to first registrar; rest is user
            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("User");
                if (checkUser is null)
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });

                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true, "Account Created");
            }
        }

        public async Task<Response<AuthenticationResponse>> GetUserByUserName(string? UserName)
        {
            AuthenticationResponse response = new AuthenticationResponse();

            var check = await userManager.FindByNameAsync(UserName);
            if(check is null) { throw new Exception("not found Account"); }
            response.UserName = check.UserName;
            response.Id= check.Id;
            return new Response<AuthenticationResponse>(response, $"Authenticated {check.UserName}");
        }

        public async Task<Response<AuthenticationResponse>> LoginAccount(LoginDTO loginDTO)
        {
            var user = await userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null)
            {
                throw new ApiException($"No Accounts Registered with {loginDTO.UserName}.");
            }
            var result = await signInManager.PasswordSignInAsync(user.UserName, loginDTO.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Invalid Credentials for '{loginDTO.UserName}'.");
            }
            
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
           
            return new Response<AuthenticationResponse>(response, $"Authenticated {user.UserName}");
        }
        private async Task<JwtSecurityToken> GenerateJWToken(UserIdentity user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

           // string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
              //  new Claim("ip", ipAddress)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config["JWTSettings:Issuer"],
                audience: config["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Double.Parse( config["JWTSettings:DurationInMinutes"])),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {


            var checkAcount  = await userManager.FindByNameAsync(model.UserName);
            // always return ok response to prevent email enumeration
            if ( checkAcount==null) return;
            var code = await userManager.GeneratePasswordResetTokenAsync(checkAcount);
            var route = "api/account/reset-password/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var emailRequest = new EmailRequest()
            {
                Body = $"You reset token is - {code}",
                To = model.Email,
                Subject = "Reset Password",
            };
           
        }
        public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
        {
            var account = await userManager.FindByEmailAsync(model.UserName);
            if (account == null) throw new ApiException($"No Accounts Registered with {model.UserName}.");
            var result = await userManager.ResetPasswordAsync(account, model.Token, model.Password);
            if (result.Succeeded)
            {
                return new Response<string>(model.UserName, message: $"Password Resetted.");
            }
            else
            {
                throw new ApiException($"Error occured while reseting the password.");
            }
        }
    }
}
