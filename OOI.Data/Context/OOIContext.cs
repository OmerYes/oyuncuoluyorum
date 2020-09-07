using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Data.Context
{
    public class OOIContext : DbContext
    {
        public OOIContext()
        {
            //Database.Connection.ConnectionString = "Server=195.142.153.74;Database=OOI;UID=user_ooi;PWD=123";
            Database.Connection.ConnectionString = "Server=.;Database=u8939770_OOiDB;UID=sa;PWD=123456";
            //Database.Connection.ConnectionString = "Server=.;Database=u8939770_OOiDB;Trusted_Connection=true";
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<WebUser> WebUsers { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<WebUserPhoto> WebUserPhotos { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCategory> companyCategories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<ProjectPhoto> ProjectPhotos { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertCategory> AdvertCategories { get; set; }
        public DbSet<AdvertPhoto> AdvertPhotos { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<CastPhoto> CastPhotos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<ProjectApply> ProjectApplies  { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
