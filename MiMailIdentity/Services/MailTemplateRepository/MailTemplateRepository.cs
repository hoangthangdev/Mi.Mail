using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.MailTemplateRepository
{
    public interface IMailTemplateRepository : IBaseRepository<MailTemplate> {
        IQueryable<MailTemplate> GetListFintName(string Name, int PageIndex, int PageSide, out int Total);
        List<string> GetCategoryByCurrentUser();
        List<MailTemplate> GetByCategory(string cate, string searchstring,int PageIndex, out int total);
    }

    public class MailTemplateRepository : BaseRepository<MailTemplate>, IMailTemplateRepository
    {

        public MailTemplateRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {

        }

        public List<MailTemplate> GetByCategory(string cate,string searchstring,int pageIndex, out int total)
        {
            var result = new List<MailTemplate>();
            total = 0;
            if (!string.IsNullOrEmpty(cate) && string.IsNullOrEmpty(searchstring))
            {
                result = GetByConditionPaging(r => r.Category.Contains(cate), pageIndex, 1, out total).ToList();
            }
            else if(!string.IsNullOrEmpty(cate) && !string.IsNullOrEmpty(searchstring))
            {
                result = GetByConditionPaging(r => r.Category.Contains(cate) && r.Name.Contains(searchstring), pageIndex, 1, out total).ToList();
            }

            return result;
        }

        public List<string> GetCategoryByCurrentUser()
        {
            var result = new List<string>();
            var current_user = _account.GetCurrentUserAsync();
            if (current_user != null)
            {
                var current_user_id = current_user.Id;
                var q = from t in _context.MailTemplates
                        where t.INS_UID.Equals(current_user_id) && !string.IsNullOrEmpty(t.Category)
                        select t.Category;
                var qr = q.Distinct().ToList();
                foreach(var item in qr)
                {
                    if (item.Contains(','))
                    {
                        var s = item.Split(',').ToList();
                        for (int i = 0; i < s.Count(); i++)
                            s[i] = s[i].Trim();
                        result.AddRange(s);
                    }
                    else
                    {
                        result.Add(item);
                    }
                }
            }
            
            return result.Distinct().ToList();
        }

        public IQueryable<MailTemplate> GetListFintName(string Name ,int PageIndex ,int PageSide,out int Total )
        {
            IQueryable<MailTemplate> result;
            result = GetAll();
            if(!string.IsNullOrEmpty(Name))
            {
                result = GetByConditionPaging(x => x.Name.Contains(Name) && x.INS_UID.Equals(""), PageIndex, PageSide, out Total);
            }
            else
            {
                result = GetAllPaging(PageIndex, PageSide, out Total);
            }
            return result;
        }
    }
}
