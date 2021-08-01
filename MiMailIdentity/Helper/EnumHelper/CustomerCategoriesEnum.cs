using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Helper.EnumHelper
{
    public enum CustomerCategoriesTypeEnum
    {
        Default = 0,
        Type_1 = 1,
        Type_2 = 2
    }

    public enum CustomerCategoriesStatusEnum
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
