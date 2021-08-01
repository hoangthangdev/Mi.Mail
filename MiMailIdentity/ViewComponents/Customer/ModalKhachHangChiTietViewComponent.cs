using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Services.CustomerRepository;

namespace MiMailIdentity.ViewComponents.Customer
{
    public class ModalKhachHangChiTietViewComponent : ViewComponent
    {
        private ICustomerRepository _repon;
        public ModalKhachHangChiTietViewComponent(ICustomerRepository repon)
        {
            _repon = repon;
        }
        public IViewComponentResult Invoke(int Id)
        {
            var result = _repon.GetById(Id);
            return View(result);
        }
    }
}
