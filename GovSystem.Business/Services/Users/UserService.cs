using GovSystem.Business.Entities;
using GovSystem.Business.Repository.Users;
using GovSystem.Common.Dto;
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

        public async Task<dynamic> LoginUser(UserLoginDto loginDto)
        {
            string Pw = Common.Methods.Common.Encrypt(loginDto.Password);
            var res = await _iDInitializer.LoginUser(loginDto.UserName, Pw);
            return res;
        }
    }
}
