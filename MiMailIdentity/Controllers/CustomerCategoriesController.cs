using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Models;
using MiMailIdentity.Services.CustomerCategoryRepository;

namespace MiMailIdentity.Controllers
{
    public class CustomerCategoriesController : Controller
    {
        private ICustomerCategoryRepository _repo;
        public CustomerCategoriesController(ICustomerCategoryRepository repository)
        {
            _repo = repository;
        }

        #region Nghiep vu
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            if (id > 0)
            {
                var result = _repo.GetById(id);
                return Ok(result);
            }
            return BadRequest("Not Spectificed category");
        }
        [HttpPost]
        public IActionResult Load(int pageIndex, int pageSize)
        {
            return ViewComponent("ListCustomerCategories", new { pageIndex = pageIndex, pageSize = pageSize });
        }
        [HttpPost]
        public IActionResult Save(CustomerCategory category)
        {
            if (category.Name.Equals("error"))
            {
                return BadRequest("Error Sample");
            }
            if (category != null)
            {
                if (category.Id <= 0)
                {
                    _repo.Insert(category);
                    return Ok("Create Successful!");
                }
                if (category.Id > 0)
                {
                    _repo.Update(category);
                    return Ok("Update Successful!");
                }
            }

            return BadRequest("Not Spectificed category");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _repo.Delete(id);
                return Ok("Delete Successful!");
            }
            return BadRequest("Not Spectificed category");
        }
        #endregion

        #region Giao Dien
        [HttpPost]
        public IActionResult GetAddEditModal(int id)
        {
            return ViewComponent("SaveCustomerCategories", new { id = id});
        }
        #endregion

    }
}
