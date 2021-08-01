using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.CustomerCategoryRepository
{
    public interface ICustomerCategoryRepository : IBaseRepository<CustomerCategory>
    {

    }

    public class CustomerCategoryRepository : BaseRepository<CustomerCategory>, ICustomerCategoryRepository
    {
        public CustomerCategoryRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account) { }

    }
}
