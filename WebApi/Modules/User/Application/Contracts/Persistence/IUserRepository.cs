

using WebApi.Modules.Constants;
using WebApi.Modules.Dtos;
using WebApi.Wrappers;
using WebApi.Wrappers.DTOS.EmailDtos;
using static WebApi.Modules.Dtos.ServiceResponses;


namespace WebApi.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<GeneralResponse> CreateAccount(UserDtos userDTO);
        Task<Response<AuthenticationResponse>> LoginAccount(LoginDTO loginDTO);
        Task<Response<AuthenticationResponse>> GetUserByUserName(string? UserName);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
