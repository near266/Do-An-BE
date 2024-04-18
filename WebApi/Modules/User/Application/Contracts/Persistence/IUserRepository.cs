

using WebApi.Modules.Constants;
using WebApi.Modules.Dtos;
using WebApi.Wrappers;
using static WebApi.Modules.Dtos.ServiceResponses;


namespace WebApi.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        Task<GeneralResponse> CreateAccount(UserDtos userDTO);
        Task<Response<AuthenticationResponse>> LoginAccount(LoginDTO loginDTO);
        Task<Response<AuthenticationResponse>> GetUserByUserName(string? UserName);
    }
}
