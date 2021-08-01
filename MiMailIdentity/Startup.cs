using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMailIdentity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiMailIdentity.Areas.Data;
using MiMailIdentity.Services.BaseRepository;
using MiMailIdentity.Services.CampaignRepository;
using MiMailIdentity.Services.CampaignCateroryRepository;
using MiMailIdentity.Services.CustomerCategoryRepository;
using MiMailIdentity.Services.CustomerRepository;
using MiMailIdentity.Services.CustomerCampaignRepository;
using MiMailIdentity.Services.MailTemplateRepository;
using MiMailIdentity.Services.ServiceRepository;
using MiMailIdentity.Services.UserServiceRepository;
using MiMailIdentity.Helper.AccountHelper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MiMailIdentity.Services.TestDemoRepository;
using MiMailIdentity.Services.BuldingItemRepository;

namespace MiMailIdentity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            #region RepositoryInjection
            //Base
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            //Entities
            services.AddScoped<ICampaignCategoryRepository, CampaignCategoryRepository>();
            services.AddScoped<ICampaignRepostitory, CampaignRepository>();
            services.AddScoped<ICustomerCategoryRepository, CustomerCategoryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerCampaignRepository, CustomerCampaignRepository>();
            services.AddScoped<IMailTemplateRepository, MailTemplateRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserServiceRepository, UserServiceRepository>();
            services.AddScoped<ITestDemoRepository, TestDemoRepository>();
            services.AddScoped<IBuildingItemRepository, BuildingItemRepository>();
            //Helper
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IAccountHelper, AccountHelper>();
            #endregion



            services.AddDbContext<ModelDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            
            
            #region Identity
            services.AddDefaultIdentity<AppUser>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            });
            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = false;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            //    options.LoginPath = "/Identity/Account/Login";
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            //    options.SlidingExpiration = true;
            //});
            #endregion


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=IndexPublic}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CustomerCategories",
                    template: "nhom-kh",
                    defaults: new { controller = "CustomerCategories", action = "Index" });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Customers",
                    template: "danh-sach-kh/nhom/{cateId}",
                    defaults: new { controller = "Customers", action = "Index" });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Campaign",
                    template: "chien-dich/{type}",
                    defaults: new { controller = "Campaigns", action = "NormalCampaign" });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "TemplateIndex",
                    template: "mail-mau",
                    defaults: new { controller = "Template", action = "Index" });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "TemplateSave",
                    template: "mail-mau/save/{id}",
                    defaults: new { controller = "Template", action = "SaveLayout" });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "TemplateSave",
                    template: "mail-mau/chon-bo-cuc",
                    defaults: new { controller = "Template", action = "BuildTemplate" });
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "TemplateSave",
                    template: "mail-mau/dung-bo-cuc/{id}",
                    defaults: new { controller = "Template", action = "ConfigurationTemplate" });
            });
        }
    }
}
