using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUserService
    {
        string generateJwtToken(string user);
        bool validateUser(LoginModel loginModel);
    }
}