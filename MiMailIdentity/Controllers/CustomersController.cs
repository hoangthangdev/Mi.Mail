using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using MiMailIdentity.Services.CustomerRepository;

namespace MiMailIdentity.Controllers
{
    public interface Icustomer : IBaseRepository<Customer>
    {

    }
    public class Customerss : BaseRepository<Customer>
    {
        public Customerss(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {

        }
    }
    public class CustomersController : Controller
    {
        private ICustomerRepository _repo;
        public CustomersController(ICustomerRepository repository)
        {
            _repo = repository;
        }
        #region  Nghiep vu
        public IActionResult Index(int cateId, int? pageIndex, int? pageSize)
        {
            var index = pageIndex ?? 1;
            var size = pageSize ?? 10;
            ViewBag.CateId = cateId;
            ViewBag.index = index;
            ViewBag.size = size;
            return View();
           
        }
        //[HttpPost]
        //public IActionResult Load((FilterCustomer filter)
        //{
        //    return ViewComponent("ListCustomer", new { CateId = cateId, PageIndex = pageIndex, PageSize = pageSize });
        //}
        [HttpPost]
        public IActionResult Save(Customer cus)
        {
            if(cus != null)
            {
                if(cus.Id > 0)
                {
                    //update
                    _repo.Update(cus);
                    return Ok(new { Status = true, mess = "Update Successful" });
                    
                }
                else if(cus.Id <= 0)
                {
                    //insert
                    _repo.Insert(cus);
                    return Ok(new {Status = true,mess = "Save Successful" });
                }
            }
            return BadRequest(new { Status = false, mess = "save erro" });
        }
        [HttpPost]
        public IActionResult Filter(FilterCustomer filter)
        {
            
            return ViewComponent("ListCustomer", new { filter = filter });
        }
        #endregion

        #region Giao Dien
        [HttpPost]
        public IActionResult AddModal(int Id)
        {
            return ViewComponent("ModalSave", new { Id = Id });
        }
        public IActionResult OpenModalChiTiet(int Id)
        {
            return ViewComponent("ModalKhachHangChiTiet", new { Id = Id });
        }
        #endregion
    }
}
