using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Areas.Data
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public int Lever { get; set; }
        public int MaxMail { get; set; }

    }
}
