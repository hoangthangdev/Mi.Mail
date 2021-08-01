using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.CustomerCampaignRepository
{
    public interface ICustomerCampaignRepository : IBaseRepository<CustomerCampaign>
    {

    }

    public class CustomerCampaignRepository : BaseRepository<CustomerCampaign>, ICustomerCampaignRepository
    {
        public CustomerCampaignRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {

        }
    }
}
