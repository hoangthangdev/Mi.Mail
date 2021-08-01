using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.CustomerRepository
{
    public class FilterCustomer
    {
        public string Name { get; set; }
        public int CateId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
