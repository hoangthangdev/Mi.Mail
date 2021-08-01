using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiMailIdentity.Areas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class UserService : BaseModel
    {
        public int ServiceId { get; set; }
        public string UserId { get; set; }
        public decimal RealPrice { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? StartActiveDate { get; set; }
        public DateTime? EndActiveDate { get; set; }

        [ForeignKey("ServiceId")]
        public virtual Service GetService { get; set; }
        [ForeignKey("UserId")]
        public virtual AppUser GetUser { get; set; }

    }
}
