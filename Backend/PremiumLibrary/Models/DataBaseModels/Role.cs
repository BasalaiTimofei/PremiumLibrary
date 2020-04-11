using System.Collections.Generic;

namespace PremiumLibrary.Models.DataBaseModels
{
    public class Role
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public virtual List<UserRole> Users { get; set; }
    }
}