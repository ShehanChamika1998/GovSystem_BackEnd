using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovSystem.Business.Entities
{
    public class User
    {
        public string? UserFullName { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserLevel { get; set; }
        public string UserAg { get; set; }
        public string UserDS_Div { get; set; }
        public  string UDistrict { get; set; }
        public string UProvince { get; set; }
        public string LogingFlag { get; set; }
        public string ClientCode { get; set; }
        public string ReciptCode { get; set; }
        public string CallPickerMaster { get; set; }
        public  string CallClientSearchFlag { get; set; }
        public  string CallReciptSearchFlag { get; set; }
        public  string UserType { get; set; }
        public  string FromDate { get; set; }
        public  string ToDate { get; set; }
        public  string MininLicenseNo { get; set; }
        public string Password { get; set; }
    }
}
