using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Services.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.ViewComponents.Customer
{
    public class ListCustomerFilterViewComponent : ViewComponent
    {
        private ICustomerRepository _repo;
        public ListCustomerFilterViewComponent(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public IViewComponentResult Invoke(FilterCustomer filter)
        {
            
            return View();
        }
    }
}
