using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Services.MailTemplateRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.ViewComponents.Template
{
    public class ListTemplateViewComponent : ViewComponent
    {
        private IMailTemplateRepository _repository;
        public ListTemplateViewComponent(IMailTemplateRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(string cate,string search,int? PageIndex)
        {
            ViewBag.Cate = cate;
            ViewBag.index = PageIndex?? 1;
            ViewBag.StSearch = search;
            return View();
        }
    }
}
