using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.TestDemoRepository
{
    public interface ITestDemoRepository : IBaseRepository<TestDemo>
    {

    }

    public class TestDemoRepository : BaseRepository<TestDemo>, ITestDemoRepository
    {
        public TestDemoRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {

        }
    }
}
