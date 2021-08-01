using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiMailIdentity.Services.CustomerRepository;
using Microsoft.AspNetCore.Mvc;

namespace MiMailIdentity.ViewComponents.Customer
{
    public class ListCustomerViewComponent : ViewComponent
    {
        private ICustomerRepository _repo;
        public ListCustomerViewComponent(ICustomerRepository customers)
        {
            _repo = customers;
        }
        public IViewComponentResult Invoke(FilterCustomer filter)
        {
           
            return View(filter);
        }
    }
}
