using MiMailIdentity.Data;
using MiMailIdentity.Helper.AccountHelper;
using MiMailIdentity.Models;
using MiMailIdentity.Services.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Services.CustomerRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer> {
        List<Customer> FilterCustomer(FilterCustomer filter, out int total);
    }

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext identityContext, ModelDbContext context, IAccountHelper account) : base(identityContext, context, account)
        {
            
        }
        public List<Customer> FilterCustomer(FilterCustomer filter, out int total)
        {
            IQueryable<Customer> result;
            result = GetAll();
            if (!string.IsNullOrEmpty(filter.Name))
            {
                result = GetByCondition(r => r.Name.Contains(filter.Name) || r.Phone.Contains(filter.Name) || r.Email.Contains(filter.Name));
            }
            if(filter.CateId > 0)
            {
                result = result.Where(r => r.CustomerCateId == filter.CateId);
            }
            if(filter.StartDate != null && filter.EndDate != null)
            {
                result = result.Where(r => r.INS_DTTM >= filter.StartDate.GetValueOrDefault() && r.INS_DTTM <= filter.EndDate.GetValueOrDefault());
            }
            total = result.Count();
            return result.Skip((filter.pageIndex - 1) * filter.pageSize).Take(filter.pageSize).ToList();
        }

    }
}
