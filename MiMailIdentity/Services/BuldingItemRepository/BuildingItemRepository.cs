using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.BuldingItemRepository
{
    public interface IBuildingItemRepository : IBaseRepository<BuildingItem> { }
    public class BuildingItemRepository : BaseRepository<BuildingItem>, IBuildingItemRepository 
    {
        public BuildingItemRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {
                
        }

    }
}
