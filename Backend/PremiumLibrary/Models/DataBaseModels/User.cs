using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels
{
    public class User
    {
        public string Id { get; set; }

        public string EmailAddress { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual List<UserRole> Roles { get; set; }
        //public virtual UserInformation UserInformation { get; set; }
    }
}