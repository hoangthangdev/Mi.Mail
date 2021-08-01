using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiMailIdentity.Areas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; } = 0;
        public int Status { get; set; } = 1;
        public string INS_UID { get; set; }
        public DateTime INS_DTTM { get; set; } = DateTime.Now;
        public string UPD_UID { get; set; }
        public DateTime UPD_DTTM { get; set; } = DateTime.Now;
    }
}
