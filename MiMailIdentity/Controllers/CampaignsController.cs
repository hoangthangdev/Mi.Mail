using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MiMailIdentity.Controllers
{
    public class CampaignsController : Controller
    {




        #region Giao dien
        public IActionResult NormalCampaign(string type)
        {
            if (type.Equals("thuong") || type.Equals("tu-dong") || type.Equals("kich-ban"))
            {
                ViewBag.Type = type;
                return View();
            }
            return BadRequest();
        }

        public IActionResult AddOrUpdateCampaign(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        #endregion



    }
}
