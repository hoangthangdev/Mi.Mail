﻿// <auto-generated />
using System;
using MiMailIdentity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MiMailIdentity.Migrations
{
    [DbContext(typeof(ModelDbContext))]
    [Migration("20200904021617_updateCustomer1")]
    partial class updateCustomer1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MiMailIdentity.Areas.Data.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Group");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("MiMailIdentity.Areas.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MiMailIdentity.Models.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CampaignCateId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<string>("Icon");

                    b.Property<string>("ListCustomerCategory");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("ScheduleTime");

                    b.Property<string>("Sender");

                    b.Property<string>("SenderDomain");

                    b.Property<int>("Status");

                    b.Property<string>("Subject");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.HasIndex("CampaignCateId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("MiMailIdentity.Models.CampaignCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<string>("Icon");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("CampaignCategories");
                });

            modelBuilder.Entity("MiMailIdentity.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Avatar");

                    b.Property<string>("CMT");

                    b.Property<int>("CustomerCateId");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.HasIndex("CustomerCateId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MiMailIdentity.Models.CustomerCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.ToTable("CustomerCategories");
                });

            modelBuilder.Entity("MiMailIdentity.Models.MailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<string>("MailBody");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.ToTable("MailTemplates");
                });

            modelBuilder.Entity("MiMailIdentity.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<decimal?>("DiscountPrice");

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Status");

                    b.Property<int>("TotalMail");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MiMailIdentity.Models.TestDemo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar");

                    b.Property<string>("Body");

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.HasKey("Id");

                    b.ToTable("TestDemos");
                });

            modelBuilder.Entity("MiMailIdentity.Models.UserService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ConfirmDate");

                    b.Property<DateTime?>("EndActiveDate");

                    b.Property<DateTime>("INS_DTTM");

                    b.Property<string>("INS_UID");

                    b.Property<decimal>("RealPrice");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime?>("StartActiveDate");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UPD_DTTM");

                    b.Property<string>("UPD_UID");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("UserServices");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("MiMailIdentity.Areas.Data.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MiMailIdentity.Areas.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MiMailIdentity.Areas.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("MiMailIdentity.Areas.Data.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MiMailIdentity.Areas.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MiMailIdentity.Areas.Data.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MiMailIdentity.Models.Campaign", b =>
                {
                    b.HasOne("MiMailIdentity.Models.CampaignCategory", "GetCategory")
                        .WithMany()
                        .HasForeignKey("CampaignCateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MiMailIdentity.Models.CampaignCategory", b =>
                {
                    b.HasOne("MiMailIdentity.Models.CampaignCategory", "GetParent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("MiMailIdentity.Models.Customer", b =>
                {
                    b.HasOne("MiMailIdentity.Models.CustomerCategory", "GetCategory")
                        .WithMany("GetCustomers")
                        .HasForeignKey("CustomerCateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MiMailIdentity.Models.UserService", b =>
                {
                    b.HasOne("MiMailIdentity.Models.Service", "GetService")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MiMailIdentity.Areas.Data.AppUser", "GetUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
