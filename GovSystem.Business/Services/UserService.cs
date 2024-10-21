using GovSystem.Business.Data;
using GovSystem.Business.Entities;
using GovSystem.Business.Interfaces;
using GovSystem.Business.Methods;

namespace GovSystem.Business.Services
{
    public class UserService : IUser
    {

        private readonly IDInitializer _iDInitializer;
        public UserService(IDInitializer dInitializer)
        {
                _iDInitializer = dInitializer;
        }
        public async Task<dynamic> CreateUser(User user)
        {
            user.Password = Common.Encrypt(user.Password);
            var res = await _iDInitializer.CreateUser(user);
            return res;
        }

        public async Task<dynamic> LoginUser(string userName, string password)
        {
            string Pw = Common.Encrypt(password);
            var res = await _iDInitializer.LoginUser(userName, Pw);
            return res;
        }
    }
}
