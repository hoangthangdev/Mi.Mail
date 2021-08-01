using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MiMailIdentity.Areas.Data;
using MiMailIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Helper.AccountHelper
{
    public interface IAccountHelper
    {
        AppUser GetCurrentUserAsync();
        List<AppUser> GetAllUsers();
        AppUser GetById(string Id);
    }
    public class AccountHelper : IAccountHelper
    {
        private UserManager<AppUser> _appUser;
        private ModelDbContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        public AccountHelper(UserManager<AppUser> appUser, IHttpContextAccessor httpContextAccessor, ModelDbContext context)
        {
            _appUser = appUser;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public List<AppUser> GetAllUsers()
        {
            var r = _context.AppUsers.ToList();
            return r;
        }

        public AppUser GetCurrentUserAsync()
        {
            var r = _appUser.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            return r;
        }
        public AppUser GetById(string Id)
        {
            var r = _context.AppUsers.Where(x => x.Id.Equals(Id)).FirstOrDefault();
            if (r != null)
                return r;
            else
                return null;
        }
    }
}
