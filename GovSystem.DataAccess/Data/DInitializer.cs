using Dapper;
using GovSystem.Business.Data;
using GovSystem.Business.Entities;
using GovSystem.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GovSystem.DataAccess.Data
{
    public class DInitializer : IDInitializer
    {

        private readonly DapperContext _context;

        public DInitializer(DapperContext context)
        {
            _context = context;
        }

        public async Task<dynamic> CreateUser(User user)
        {


            try

            {
                var query = "SP_Insert_User_Test";
                var parameters = new DynamicParameters();
                parameters.Add("userId", user.UserId);
                parameters.Add("UserName", user.UserName);
                parameters.Add("Password", user.Password);
                parameters.Add("RetValue", "1");
                using (var connection = _context.CreateConnection())
                {

                    
                    var data = await connection.QueryAsync<dynamic>(query, parameters, commandType: CommandType.StoredProcedure);
                    var returnValue = parameters.Get<string>("RetValue");

                    return returnValue;

             
                    ///return returnValue; // This will return null if no matching user is found
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
