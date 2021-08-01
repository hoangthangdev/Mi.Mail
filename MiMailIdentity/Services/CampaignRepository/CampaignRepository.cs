using Microsoft.EntityFrameworkCore;
using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.CampaignRepository
{

    public interface ICampaignRepostitory : IBaseRepository<Campaign>
    {
        Campaign GetCampaignByName(string name);
    }
    public class CampaignRepository : BaseRepository<Campaign>, ICampaignRepostitory
    {
        private DbSet<Campaign> _entities;
        private string errorMsg = string.Empty;
        public CampaignRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account) { }
        public Campaign GetCampaignByName(string name)
        {
            var result = new Campaign();
            if (!string.IsNullOrEmpty(name))
            {
                result = _entities.Where(r => r.Name.Equals(name)).FirstOrDefault();
            }
            return result;

        }
    }
}
