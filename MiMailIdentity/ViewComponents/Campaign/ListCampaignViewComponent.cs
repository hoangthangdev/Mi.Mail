using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.ViewComponents.Campaign
{
    public class ListCampaignViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int pageIndex, int pageSize, string type)
        {
            ViewBag.Index = pageIndex;
            ViewBag.Size = pageSize;
            ViewBag.Type = type;
            return View();
        }
    }
}
