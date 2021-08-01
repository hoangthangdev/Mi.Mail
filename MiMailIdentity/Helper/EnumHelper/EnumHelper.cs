using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Helper.EnumHelper
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumValue)
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }

        public static Dictionary<int, string> GetCustomerCategoryStatusEnum()
        {
            var r = new Dictionary<int, string>();
            foreach (CustomerCategoriesStatusEnum foo in System.Enum.GetValues(typeof(CustomerCategoriesStatusEnum)))
            {
                var des = foo.ToString();
                var d = foo.GetType().GetField(foo.ToString());
                if (d != null)
                {
                    var attr = d.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attr != null && attr.Length > 0)
                    {
                        des = ((DescriptionAttribute)attr[0]).Description;
                    }
                }
                r.Add((int)foo, des);
            }
            return r;
        }


        public static string GetIconColorStatusCustomerCategories(int ss)
        {
            var status = ss;
            var i_tag = "";
            switch (status)
            {
                case (int)CustomerCategoriesStatusEnum.Default:
                    i_tag = "ddefault";
                    break;
                case (int)CustomerCategoriesStatusEnum.Active:
                    i_tag = "drun";
                    break;
                case (int)CustomerCategoriesStatusEnum.Pending:
                    i_tag = "dpending";
                    break;
                case (int)CustomerCategoriesStatusEnum.DeActive:
                    i_tag = "dstop";
                    break;
            }
            return i_tag;
        }
        public static string GetIconColorStatusCampaign(int ss)
        {
            var status = ss;
            var i_tag = "";
            switch (status)
            {
                case (int)CampaignStatusEnum.Default:
                    i_tag = "ddefault";
                    break;
                case (int)CampaignStatusEnum.Active:
                    i_tag = "drun";
                    break;
                case (int)CampaignStatusEnum.Pending:
                    i_tag = "dpending";
                    break;
                case (int)CampaignStatusEnum.DeActive:
                    i_tag = "dstop";
                    break;
            }
            return i_tag;
        }

        public static Dictionary<int, string> GetCampaignStatusEnum()
        {
            var r = new Dictionary<int, string>();
            foreach (CampaignStatusEnum foo in System.Enum.GetValues(typeof(CampaignStatusEnum)))
            {
                var des = foo.ToString();
                var d = foo.GetType().GetField(foo.ToString());
                if (d != null)
                {
                    var attr = d.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attr != null && attr.Length > 0)
                    {
                        des = ((DescriptionAttribute)attr[0]).Description;
                    }
                }
                r.Add((int)foo, des);
            }
            return r;
        }
        public static Dictionary<int,string> GetCustomerGender()
        {
            var Dt = new Dictionary<int, string>();
            foreach  (CustomerEnum Gd in Enum.GetValues(typeof(CustomerEnum)))
            {
                var des = Gd.ToString();
                var Ide = Gd.GetType().GetField(des);
                if(Ide != null)
                {
                    var attr = Ide.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attr != null && attr.Length > 0)
                    {
                        des = ((DescriptionAttribute)attr[0]).Description;
                    }

                }
                Dt.Add((int)Gd, des);
            }
            return Dt;
        }
        public static string GetTextGenderByTybe(int Tybe)
        {
            var status = Tybe;
            var i_tag = "";
            switch (status)
            {
                case (int)CustomerEnum.Nam:
                    i_tag = "Nam";
                    break;
                case (int)CustomerEnum.Nu:
                    i_tag = "Nữ";
                    break;
                case (int)CustomerEnum.Khac:
                    i_tag = "Khác";
                    break;
              
            }
            return i_tag;
        }

    }
}
