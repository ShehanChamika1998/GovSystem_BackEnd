﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovSystem.Business.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string UserID { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserLevel { get; set; } = string.Empty;
        public string GN_Division { get; set; } = string.Empty;
        public string DS_Division { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CreateUser { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
