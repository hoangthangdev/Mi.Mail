using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class BuildingItem : BaseModel
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Body { get; set; }
        public string Avatar { get; set; }
    }
}
