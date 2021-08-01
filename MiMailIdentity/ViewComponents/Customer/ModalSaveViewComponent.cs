using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Models;
using MiMailIdentity.Services.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.ViewComponents.Customer
{
    
    public class ModalSaveViewComponent : ViewComponent
    {
        private ICustomerRepository _repon;
        public ModalSaveViewComponent(ICustomerRepository repon)
        {
            _repon = repon;
        }
        public IViewComponentResult Invoke(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
    }
}
