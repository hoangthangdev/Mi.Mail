using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class CustomerCampaign : BaseModel
    {
        public int CustomerId { get; set; }
        public int CampaignId { get; set; }
        public string TemplateBody { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer GetCustomer { get; set; }
        [ForeignKey("CampaignId")]
        public virtual Campaign GetCampaign { get; set; }


    }
}
