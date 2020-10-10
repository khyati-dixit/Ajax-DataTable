using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataRetrieveAajx.Entitiess
{
    public class UserDetailModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public string CivilIdNumber { get; set; }
        public string ProfilePic { get; set; }
        public string CarLicense { get; set; }
    }
}