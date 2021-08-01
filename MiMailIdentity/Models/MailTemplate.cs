using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class MailTemplate : BaseModel
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string MailBody { get; set; }
        public string Category { get; set; }
    }
}
