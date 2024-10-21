using GovSystem.Business.Entities;
using GovSystem.Business.Repository.Users;
using GovSystem.Common.Methods;

namespace GovSystem.Business.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _iDInitializer;
        public UserService(IUserRepository dInitializer)
        {
            _iDInitializer = dInitializer;
        }
        public async Task<dynamic> CreateUser(User user)
        {
            user.Password = Common.Methods.Common.Encrypt(user.Password);
            var res = await _iDInitializer.CreateUser(user);
            return res;
        }

        public async Task<dynamic> LoginUser(string userName, string password)
        {
            string Pw = Common.Methods.Common.Encrypt(password);
            var res = await _iDInitializer.LoginUser(userName, Pw);
            return res;
        }
    }
}
