using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class CampaignCategory : BaseModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual CampaignCategory GetParent { get; set; }

    }
}
