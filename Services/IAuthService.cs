using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface IAuthService
{
    Task<AuthResponseDto> Login(LoginDto loginDto);
    Task Register(RegisterDto registerDto);
    Task Logout();
}
