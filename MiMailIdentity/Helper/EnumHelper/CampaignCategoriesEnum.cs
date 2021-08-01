using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Helper.EnumHelper
{
    public enum CampaignCategoriesTypeEnum
    {
        [Description("Mặc định")]
        Default = 0,
        [Description("Thường")]
        Normal = 1,
        [Description("Tự động")]
        Auto = 2,
        [Description("Kịch bản")]
        Script = 3
    }
    public enum CampaignCategoriesStatusEnum
    {
        [Description("Mặc định")]
        Default = 0,
        [Description("Hoạt động")]
        Active = 1,
        [Description("Đang chờ")]
        Pending = 2,
        [Description("Tạm ngưng")]
        DeActive = 3,
        [Description("Xóa")]
        Delete = 4
    }
}
