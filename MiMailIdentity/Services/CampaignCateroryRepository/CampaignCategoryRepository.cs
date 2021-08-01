using Microsoft.EntityFrameworkCore;
using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.CampaignCateroryRepository
{
    public interface ICampaignCategoryRepository  : IBaseRepository<CampaignCategory>
    {
        IEnumerable<CampaignCategory> GetIconNotNull();
    }
    public class CampaignCategoryRepository : BaseRepository<CampaignCategory>, ICampaignCategoryRepository
    {
        public CampaignCategoryRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account) { }

        //Example
        public IEnumerable<CampaignCategory> GetIconNotNull()
        {
            var result = _context.CampaignCategories.Where(r => !string.IsNullOrEmpty(r.Icon));
            return result;
        }

    }
}
