using GovSystem.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovSystem.Business.Repository.Users
{
    public interface IUserRepository
    {
        Task<dynamic> CreateUser(User user);
        Task<dynamic> LoginUser(string userName, string password);
    }
}
