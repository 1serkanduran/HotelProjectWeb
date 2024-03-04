using UserManagement.Data.Models;

namespace UserManagement.Api.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Registeration(RegistrationModel model, string role);
        Task<(int, string)> Login(LoginModel model);
        Task<(int, string)> Logout(string userName);
        Task<(int, string)> ForgotPassword(ForgotPasswordModel model);
        Task<(int, string)> RemovePassword(ForgotPasswordModel model);
        Task<(int, string)> AddPassword(LoginModel model);
    }
}
