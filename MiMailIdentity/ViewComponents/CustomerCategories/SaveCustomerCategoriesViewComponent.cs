using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Services.CustomerCategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.ViewComponents.CustomerCategories
{
    public class SaveCustomerCategoriesViewComponent : ViewComponent
    {
        private ICustomerCategoryRepository _repository;
        public SaveCustomerCategoriesViewComponent(ICustomerCategoryRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
