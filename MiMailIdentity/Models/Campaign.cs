using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class Campaign : BaseModel
    {
        public int CampaignCateId { get; set; }
        public string Name { get; set; }
        public string Sender { get; set; }
        public string ListCustomerCategory { get; set; } // Danh sach customerCategoryId
        public string Subject { get; set; }
        public string SenderDomain { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public DateTime? ScheduleTime { get; set; }
        


        [ForeignKey("CampaignCateId")]
        public virtual CampaignCategory GetCategory { get; set; }

        public virtual ICollection<CustomerCampaign> GetCustomerCampaigns { get; set; }
    }
}
