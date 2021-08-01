using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Services.CustomerCategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace MiMailIdentity.ViewComponents.CustomerCategories
{
    public class ListCustomerCategoriesViewComponent : ViewComponent
    {
        private ICustomerCategoryRepository _repository;
        public ListCustomerCategoriesViewComponent(ICustomerCategoryRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int CateId, int PageIndex, int PageSize)
        {
            ViewBag.Index = PageIndex;
            ViewBag.Size = PageSize;
            return View();
        }
    }
}
