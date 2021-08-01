using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiMailIdentity.Models;
using MiMailIdentity.Services.TestDemoRepository;

namespace MiMailIdentity.Controllers
{
    public class TestDemosController : Controller
    {
        private ITestDemoRepository _testDemoRepository;
        public TestDemosController(ITestDemoRepository testDemoRepository)
        {
            _testDemoRepository = testDemoRepository;
        }
        [HttpPost]
        public IActionResult Save(TestDemo demo)
        {
            if(demo != null)
            {
                if(demo.Id <= 0)
                {
                    _testDemoRepository.Insert(demo);
                    return Ok("Insert success!");
                }
                if(demo.Id > 0)
                {
                    _testDemoRepository.Update(demo);
                    return Ok("Update Success!");
                }
            }
            return BadRequest();
        }
        //[HttpPost("Demo/{id}")]
        public IActionResult Demo(int? id)
        {
            id = id ?? 0;
            ViewBag.Id = id;
            return View();
        }
    }
}
