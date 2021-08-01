using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.UserServiceRepository
{
    public interface IUserServiceRepository : IBaseRepository<UserService> { }
    public class UserServiceRepository : BaseRepository<UserService>, IUserServiceRepository
    {

        public UserServiceRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base (identityContext,context, account)
        {

        }
    }
}
