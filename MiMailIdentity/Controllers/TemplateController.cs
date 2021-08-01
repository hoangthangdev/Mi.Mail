using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Helper.TempLateHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.MailTemplateRepository;

namespace MiMailIdentity.Controllers
{
    public class TemplateController : Controller
    {
        private IMailTemplateRepository _repon;
        public TemplateController(IMailTemplateRepository repons)
        {
            _repon = repons;
        }
        #region Giao dien
        public IActionResult Index()
        {
            var total = 0;
            var r = _repon.GetByConditionPaging(x => x.INS_UID.Equals(""), 1, 10, out total);
            ViewBag.Total = total;
            return View(r);
        }
        public IActionResult SaveLayout(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult BuildTemplate() {
            return View();
        }

        public IActionResult ConfigurationTemplate(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        public IActionResult ListTempPlate(string cateName ,string search,int Index)
        {
            return ViewComponent("ListTemplate", new { cate = cateName, search = search, PageIndex = Index });
        } 
        #endregion

        #region Nghiep Vu
        [HttpPost]
        public IActionResult SaveTemplate(MailTemplate template)
        {
            if(template != null)
            {
                if (template.Id <= 0)
                {
                    _repon.Insert(template);
                    return Ok("Create Template Success");
                }
                if (template.Id > 0)
                {
                    _repon.Insert(template);
                    return Ok("Save Template Success");
                }
            }
            return BadRequest("Error!");
        }
        public IActionResult GetAllcateTemp()
        {
            var rs = _repon.GetCategoryByCurrentUser();
            return Ok(rs);
        }
        public IActionResult PhotoImgByHtml(string html)
        {
            TeampLateHelper.ConvertHtmlToImage(html);
            return Ok();
        }
        #endregion



    }
}