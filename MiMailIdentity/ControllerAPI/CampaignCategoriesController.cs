using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal;
using MiMailIdentity.Models;
using MiMailIdentity.Services.CampaignCateroryRepository;

namespace MiMailIdentity.ControllerAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignCategoriesController : ControllerBase
    {
        private ICampaignCategoryRepository _repo;
        public CampaignCategoriesController(ICampaignCategoryRepository repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Route("Save")]
        public IActionResult Save([FromBody] CampaignCategory category)
        {
            if(category != null)
            {
                if(category.Id <= 0)
                {
                    _repo.Insert(category);
                    return Ok("Insert CampaignCategory Success!");
                }
                if(category.Id > 0)
                {
                    _repo.Update(category);
                    return Ok("Update CampaignCategory Success!");
                }
            }
            return BadRequest("Not Spectificed CampaignCategory");
        }
    }
}
