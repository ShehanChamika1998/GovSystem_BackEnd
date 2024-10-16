using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovSystem.DataAccess.Common
{
    public class DbConnecter
    {
        public SqlConnection openConnection()
        {


            string connetionString = @"Data Source=LAPTOP-S3U39OVO;Initial Catalog=GovProjectTracker;Integrated Security=True";


            SqlConnection cnn = new SqlConnection(connetionString);

            cnn.Open();


            return cnn;


        }
    }
}
