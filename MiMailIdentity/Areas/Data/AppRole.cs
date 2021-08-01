using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Areas.Data
{
    public class AppRole : IdentityRole
    {
        public string Group { get; set; }
    }
}
