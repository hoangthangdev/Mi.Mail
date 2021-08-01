using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class CustomerCategory : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Customer> GetCustomers { get; set; }
    }
}
