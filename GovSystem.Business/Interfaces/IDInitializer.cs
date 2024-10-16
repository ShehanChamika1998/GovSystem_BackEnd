using GovSystem.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovSystem.Business.Data
{
    public interface IDInitializer
    {
        Task<dynamic> CreateUser(User user);
    }
}
