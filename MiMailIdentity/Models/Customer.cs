using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class Customer : BaseModel
    {
        public int CustomerCateId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string CMT { get; set; }
        public int Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        

        [ForeignKey("CustomerCateId")]
        public virtual CustomerCategory GetCategory { get; set; }
    }
}
