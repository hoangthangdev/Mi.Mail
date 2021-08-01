using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiMailIdentity.Areas.Data;
using MiMailIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiMailIdentity.Data
{
    public partial class ModelDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
        {
        }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<CampaignCategory> CampaignCategories { get; set; }
        public virtual DbSet<Campaign> Campaigns { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MailTemplate> MailTemplates { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<UserService> UserServices { get; set; }
        public virtual DbSet<BuildingItem> BuildingItems { get; set; }
        public virtual DbSet<TestDemo> TestDemos { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
