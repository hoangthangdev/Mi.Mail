using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiMailIdentity.Areas.Data;
using MiMailIdentity.Models;

namespace MiMailIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //public virtual DbSet<CampaignCategory> CampaignCategories { get; set; }
        //public virtual DbSet<Campaign> Campaigns { get; set; }
        //public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<MailTemplate> MailTemplates { get; set; }
        //public virtual DbSet<Service> Services { get; set; }
        //public virtual DbSet<UserService> UserServices { get; set; }
    }
}
