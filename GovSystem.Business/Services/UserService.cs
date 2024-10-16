using GovSystem.Business.Data;
using GovSystem.Business.Entities;
using GovSystem.Business.Interfaces;

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
            var res = await _iDInitializer.CreateUser(user);
            return res;
        }
    }
}
