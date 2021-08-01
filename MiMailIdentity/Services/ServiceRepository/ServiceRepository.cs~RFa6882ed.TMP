using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.ServiceRepository
{

    public interface IServiceRepository : IBaseRepository<Service> { }
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {

        }
    }
}
