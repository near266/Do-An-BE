using Azure.Core;
using Firebase.Auth;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using WebApi.Domain.Abstractions;
using WebApi.Domain.Entites;
using WebApi.Modules.Constants;
using WebApi.Modules.Dtos;
using WebApi.Modules.Email.Interface;
using WebApi.Modules.User.Domain.Entites;
using WebApi.Shared.Constants;
using WebApi.Wrappers;
using WebApi.Wrappers.DTOS.EmailDtos;
using static WebApi.Modules.Dtos.ServiceResponses;


namespace WebApi.Modules.User.Infrastructure.Persistence.Repositories
{
    public class UserRepository(UserManager<UserIdentity> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config,
         JWTSettings jwtSettings,
         SignInManager<UserIdentity> signInManager,
         IEmailServices emailServices,
         ICustomerSupportDbContext context
        ) : IUserRepository
    {
        private readonly ICustomerSupportDbContext _context = context;
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
            if (check is null) { throw new Exception("not found Account"); }
            response.UserName = check.UserName;
            response.Id = check.Id;
            return new Response<AuthenticationResponse>(response, $"Authenticated {check.UserName}");
        }

        public async Task<Response<AuthenticationResponse>> LoginAccount(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            
            if (user == null)
            {
                throw new ApiException($"No Accounts Registered with {loginDTO.Email}.");
            }
            var result = await signInManager.PasswordSignInAsync(user.UserName , loginDTO.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Invalid Credentials for '{loginDTO.Email  }'.");
            }
            if(user.IsLockedOut)
            {
                AuthenticationResponse Ban = new AuthenticationResponse
                {
                    Id = null,
                    JWTToken = "",
                    Email = user.Email,
                    UserName = user.UserName,
                    IsBan = 1,
                    Roles = [],
                };
                return new Response<AuthenticationResponse>(Ban, $"IsBan {user.UserName}");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(user);
            AuthenticationResponse response = new AuthenticationResponse
            {
                Id = user.Id,
                JWTToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };
            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            var refreshToken = new JwtSecurityTokenHandler().WriteToken(await GenerateRefreshToken(user));
            await _context.RefreshTokens.AddAsync(new RefreshToken() { Token = refreshToken, UserId = user.Id, IssueAt = DateTime.UtcNow, ExpireAt = DateTime.UtcNow.AddDays(Double.Parse(config["RefreshTokenSettings:DurationInDays"])) });
            response.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();
            return new Response<AuthenticationResponse>(response, $"Authenticated {user.UserName}");
        }
        public async Task<GeneralResponse> LogoutAccount(RefreshTokenDTO refreshTokenDto)
        {
            var payload = GetPrincipalFromToken(refreshTokenDto.Token);
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshTokenDto.Token);
            if (refreshToken is null) return new GeneralResponse(false, "Invalid Token");
            var userId = payload.Claims.Single(x => x.Type == "uid").Value;
            if (userId != refreshToken.UserId) return new GeneralResponse(false, "Invalid Token");
            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
            return new GeneralResponse(true, "Logged Out Successfully");
        }

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["RefreshTokenSettings:Key"])),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid Token");
            return principal;
        }

        public async Task<Response<AuthenticationResponse>> RefreshToken(RefreshTokenDTO refreshTokenDto)
        {
            var payload = GetPrincipalFromToken(refreshTokenDto.Token);
            Console.WriteLine(payload.Claims);
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshTokenDto.Token);
            if (refreshToken is null) return new Response<AuthenticationResponse>(null, "Token is not found or expired.");
            var user = await userManager.FindByIdAsync(payload.Claims.Single(x => x.Type == "uid").Value);
            if (user is null) return new Response<AuthenticationResponse>(null, "Invalid Token");
            var rolesList = await userManager.GetRolesAsync(user).ConfigureAwait(false);
            var response = new AuthenticationResponse()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = rolesList.ToList(),
                IsVerified = user.EmailConfirmed,
                JWTToken = new JwtSecurityTokenHandler().WriteToken(await GenerateJWTToken(user)),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(await GenerateRefreshToken(user))
            };
            _context.RefreshTokens.Remove(refreshToken);
            await _context.RefreshTokens.AddAsync(new RefreshToken() { Token = response.RefreshToken, UserId = user.Id, IssueAt = DateTime.UtcNow, ExpireAt = DateTime.UtcNow.AddDays(Double.Parse(config["RefreshTokenSettings:DurationInDays"])) });
            await _context.SaveChangesAsync();
            return new Response<AuthenticationResponse>(response, "Token Refreshed");
        }
        private async Task<JwtSecurityToken> GenerateJWTToken(UserIdentity user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config["JWTSettings:Issuer"],
                audience: config["JWTSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Double.Parse(config["JWTSettings:DurationInMinutes"])),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        private async Task<JwtSecurityToken> GenerateRefreshToken(UserIdentity user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["RefreshTokenSettings:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: config["RefreshTokenSettings:Issuer"],
                audience: config["RefreshTokenSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(Double.Parse(config["RefreshTokenSettings:DurationInDays"])),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var checkAcount = await userManager.FindByNameAsync(model.UserName);
            // always return ok response to prevent email enumeration
            if (checkAcount == null) return;
            var code = await userManager.GeneratePasswordResetTokenAsync(checkAcount);
            var route = "api/account/reset-password/";
            var emailRequest = new EmailRequest()
            {
                Body = $"You reset token is - {code}",
                To = model.Email,
                Subject = "Reset Password",
            };
            await emailServices.SendAsync(emailRequest);
        }
        public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
        {
            var account = await userManager.FindByNameAsync(model.UserName);
         
            if (account == null) throw new ApiException($"No Accounts Registered with {model.UserName}.");
            var checkpass = await userManager.CheckPasswordAsync(account,model.OldPass);
            if (!checkpass) throw new ApiException("Old Password Wrong");
            var code = await userManager.GeneratePasswordResetTokenAsync(account);

            var result = await userManager.ResetPasswordAsync(account, code, model.Password);
            if (result.Succeeded)
            {
                return new Response<string>(model.UserName, message: $"Password Resetted.");
            }
            else
            {
                throw new ApiException($"Error occured while reseting the password.");
            }
        }

        public async Task<GeneralResponse> CreateAccountAdmin(UserDtos userDtos)
        {
            if (userDtos is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new UserIdentity()
            {
                Name = userDtos.Name,
                Email = userDtos.Email,
                PasswordHash = userDtos.Password,
                UserName = userDtos.UserName,

            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User registered already");

            var createUser = await userManager.CreateAsync(newUser!, userDtos.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error occured.. please try again");

            //Assign Default Role : Admin to first registrar; rest is user
        
         
           
                var checkUser = await roleManager.FindByNameAsync("Admin");
                if (checkUser is null)
                    await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });

                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created");
           
        }

        public async Task<GeneralResponse> CreateAccountEnterprise(UserDtos userDTO)
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



            var checkUser = await roleManager.FindByNameAsync("Enterprise");
            if (checkUser is null)
                await roleManager.CreateAsync(new IdentityRole() { Name = "Enterprise" });

            await userManager.AddToRoleAsync(newUser, "Enterprise");
            return new GeneralResponse(true, "Account Created");
        }

        public async Task<Response<AuthenticationResponse>> getUserbyId(string id)
        {
            AuthenticationResponse response = new AuthenticationResponse();

            var check = await userManager.FindByIdAsync(id);
            if (check is null) { throw new Exception("not found Account"); }
            response.UserName = check.UserName;
            response.Id = check.Id;
            response.Email = check.Email;
            return new Response<AuthenticationResponse>(response, $"Authenticated {check.UserName}");
        }

        public async Task<int> LockUser(string UserId)
        {
            var user = await userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return 0;
            }

            user.IsLockedOut = true;
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return 1;
            }

            return 0;
        }

        public async Task<int> UnLockUser(string UserId)
        {
            var user = await userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return 0;
            }

            user.IsLockedOut = false;
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return 1;
            }

            return 0;
        }
    }
}
