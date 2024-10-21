using Dapper;
using GovSystem.Business.Data;
using GovSystem.Business.Entities;
using GovSystem.Business.Interfaces;
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
                var query = "[Gov].[SP_Insert_User_V2]";
                var parameters = new DynamicParameters();
                parameters.Add("UserId", await GetUserIdAsync(user.UserID));
                parameters.Add("UserName", user.UserName);
                parameters.Add("Password", user.Password);
                parameters.Add("FullName", user.FullName);
                parameters.Add("UserType", user.UserType);
                parameters.Add("District", user.District);
                parameters.Add("DS_Division", user.DS_Division);
                parameters.Add("GN_Division", user.GN_Division);
                parameters.Add("CreateUser", user.CreateUser);
                using (var connection = _context.CreateConnection())
                {


                    var data = await connection.QueryAsync<dynamic>(query, parameters, commandType: CommandType.StoredProcedure);
                    

                    return data;


                    ///return returnValue; // This will return null if no matching user is found
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> GetUserIdAsync(string UserId)
        {

            using (var con = _context.CreateConnection())
            {
                var commandText = "SELECT TOP 1 UserID FROM [Gov].[Tbl_User] ORDER BY UserID DESC";

                // Use Dapper's QueryFirstOrDefaultAsync to get the Project_ID
                var QRCode = await con.QueryFirstOrDefaultAsync<string>(commandText);

                if (QRCode != null) // If a Project_ID is found
                {
                    string ID = QRCode.Substring(4); // Extract numeric part after "USR-"

                    // Increment the numeric part
                    int id = Convert.ToInt32(ID) + 1;

                    // Format the new ID with leading zeros
                    string b = id.ToString("D5");

                    // Construct the new UserId
                    UserId = QRCode.Substring(0, 4) + b;
                }
                else
                {
                    // In case there are no records, return the default UserId
                    UserId = "USR-00001";
                }

                return UserId;  // Return the newly generated or default UserId
            }
        }

        public async Task<dynamic> LoginUser(string userName, string password)
        {
            try

            {
                var query = "[Gov].[SP_Login_Details]";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("Password", password);

                using (var connection = _context.CreateConnection())
                {


                    var data = await connection.ExecuteScalarAsync<int>(query, parameters, commandType: CommandType.StoredProcedure);


                    return data;


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
