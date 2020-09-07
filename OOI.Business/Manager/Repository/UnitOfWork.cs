using OOI.Data.Context;
using OOI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOI.Business.Manager.Repository
{
    public class UnitOfWork : IDisposable
    {
        private OOIContext ooiContext = new OOIContext();
        public UnitOfWork()
        {
            ooiContext = new OOIContext();
        }
        public UnitOfWork(OOIContext db)
        {
            ooiContext = db;
        }
        private GenericRepository<AdminUser> adminUserRepo;
        private GenericRepository<Blog> blogRepo;
        private GenericRepository<BlogCategory> blogCategoryRepo;
        private GenericRepository<WebUser> webUserRepo;
        private GenericRepository<WebUserPhoto> webUserPhotoRepo;
        private GenericRepository<Company> companyRepo;
        private GenericRepository<CompanyCategory> companyCategoryRepo;
        private GenericRepository<Project> projectRepo;
        private GenericRepository<ProjectCategory> projectCategoryRepo;
        private GenericRepository<ProjectPhoto> projectPhotoRepo;
        private GenericRepository<Advert> advertRepo;
        private GenericRepository<AdvertPhoto> advertPhotoRepo;
        private GenericRepository<AdvertCategory> advertCategoryRepo;
        private GenericRepository<Cast> castRepo;
        private GenericRepository<CastPhoto> castPhotoRepo;
        private GenericRepository<City> cityRepo;
        private GenericRepository<ProjectUser> projectuserRepo;
        private GenericRepository<ProjectApply> projectapplyRepo;
        private GenericRepository<Order> orderRepo;
        private GenericRepository<Interview> interviewRepo;
        private GenericRepository<Promotion> promotionRepo;
        private GenericRepository<Opportunity> opportunityRepo;
        private GenericRepository<Product> productRepo;
        private GenericRepository<OrderDetails> orderdetailsRepo;
        private GenericRepository<UserExperience> userExperienceRepo;
        private GenericRepository<Contact> contactRepo;

        public GenericRepository<Contact> ContactRepo
        {
            get
            {
                if (this.contactRepo == null)
                {
                    this.contactRepo = new GenericRepository<Contact>(ooiContext);
                }
                return contactRepo;
            }
        }
        public GenericRepository<Product> ProductRepo
        {
            get
            {
                if (this.productRepo == null)
                {
                    this.productRepo = new GenericRepository<Product>(ooiContext);
                }
                return productRepo;
            }
        }

        public GenericRepository<UserExperience> UserExperienceRepo
        {
            get
            {
                if (this.userExperienceRepo == null)
                {
                    this.userExperienceRepo = new GenericRepository<UserExperience>(ooiContext);
                }
                return userExperienceRepo;
            }
        }

        public GenericRepository<OrderDetails> OrderDetailsRepo
        {
            get
            {
                if (this.orderdetailsRepo == null)
                {
                    this.orderdetailsRepo = new GenericRepository<OrderDetails>(ooiContext);
                }
                return orderdetailsRepo;
            }
        }
        public GenericRepository<Promotion> PromotionRepo
        {
            get
            {
                if (this.promotionRepo == null)
                {
                    this.promotionRepo = new GenericRepository<Promotion>(ooiContext);
                }
                return promotionRepo;
            }
        }

        public GenericRepository<Opportunity> OpportunityRepo
        {
            get
            {
                if (this.opportunityRepo == null)
                {
                    this.opportunityRepo = new GenericRepository<Opportunity>(ooiContext);
                }
                return opportunityRepo;
            }
        }

        public GenericRepository<Order> OrderRepo
        {
            get
            {
                if (this.orderRepo == null)
                {
                    this.orderRepo = new GenericRepository<Order>(ooiContext);
                }
                return orderRepo;
            }
        }
        public GenericRepository<ProjectApply> ProjectApplyRepo
        {
            get
            {
                if (this.projectapplyRepo == null)
                {
                    this.projectapplyRepo = new GenericRepository<ProjectApply>(ooiContext);
                }
                return projectapplyRepo;
            }
        }


        public GenericRepository<City> CityRepo
        {
            get
            {
                if (this.cityRepo == null)
                {
                    this.cityRepo = new GenericRepository<City>(ooiContext);
                }
                return cityRepo;
            }
        }
        public GenericRepository<CastPhoto> CastPhotoRepo
        {
            get
            {
                if (this.castPhotoRepo == null)
                {
                    this.castPhotoRepo = new GenericRepository<CastPhoto>(ooiContext);
                }
                return castPhotoRepo;
            }
        }
        public GenericRepository<Cast> CastRepo
        {
            get
            {
                if (this.castRepo == null)
                {
                    this.castRepo = new GenericRepository<Cast>(ooiContext);
                }
                return castRepo;
            }
        }
        public GenericRepository<AdvertCategory> AdvertCategoryRepo
        {
            get
            {
                if (this.advertCategoryRepo == null)
                {
                    this.advertCategoryRepo = new GenericRepository<AdvertCategory>(ooiContext);
                }
                return advertCategoryRepo;
            }
        }
        public GenericRepository<AdvertPhoto> AdvertPhotoRepo
        {
            get
            {
                if (this.advertPhotoRepo == null)
                {
                    this.advertPhotoRepo = new GenericRepository<AdvertPhoto>(ooiContext);
                }
                return advertPhotoRepo;
            }
        }
        public GenericRepository<Advert> AdvertRepo
        {
            get
            {
                if (this.advertRepo == null)
                {
                    this.advertRepo = new GenericRepository<Advert>(ooiContext);
                }
                return advertRepo;
            }
        }
        public GenericRepository<ProjectPhoto> ProjectPhotoRepo
        {
            get
            {
                if (this.projectPhotoRepo == null)
                {
                    this.projectPhotoRepo = new GenericRepository<ProjectPhoto>(ooiContext);
                }
                return projectPhotoRepo;
            }
        }
        public GenericRepository<ProjectCategory> ProjectCategoryRepo
        {
            get
            {
                if (this.projectCategoryRepo == null)
                {
                    this.projectCategoryRepo = new GenericRepository<ProjectCategory>(ooiContext);
                }
                return projectCategoryRepo;
            }
        }
        public GenericRepository<Project> ProjectRepo
        {
            get
            {
                if (this.projectRepo == null)
                {
                    this.projectRepo = new GenericRepository<Project>(ooiContext);
                }
                return projectRepo;
            }
        }

        public GenericRepository<ProjectUser> ProjectUserRepo
        {
            get
            {
                if (this.projectuserRepo == null)
                {
                    this.projectuserRepo = new GenericRepository<ProjectUser>(ooiContext);
                }
                return projectuserRepo;
            }
        }
        public GenericRepository<CompanyCategory> CompanyCategoryRepo
        {
            get
            {
                if (this.companyCategoryRepo == null)
                {
                    this.companyCategoryRepo = new GenericRepository<CompanyCategory>(ooiContext);
                }
                return companyCategoryRepo;
            }
        }
        public GenericRepository<Company> CompanyRepo
        {
            get
            {
                if (this.companyRepo == null)
                {
                    this.companyRepo = new GenericRepository<Company>(ooiContext);
                }
                return companyRepo;
            }
        }
        public GenericRepository<WebUserPhoto> WebUserPhotoRepo
        {
            get
            {
                if (this.webUserPhotoRepo == null)
                {
                    this.webUserPhotoRepo = new GenericRepository<WebUserPhoto>(ooiContext);
                }
                return webUserPhotoRepo;
            }
        }
        public GenericRepository<AdminUser> AdminUserRepo
        {
            get
            {
                if (this.adminUserRepo == null)
                {
                    this.adminUserRepo = new GenericRepository<AdminUser>(ooiContext);
                }
                return adminUserRepo;
            }
        }
        public GenericRepository<Blog> BlogRepo
        {
            get
            {
                if (this.blogRepo == null)
                {
                    this.blogRepo = new GenericRepository<Blog>(ooiContext);
                }
                return blogRepo;
            }
        }
        public GenericRepository<BlogCategory> BlogCategoryRepo
        {
            get
            {
                if (this.blogCategoryRepo == null)
                {
                    this.blogCategoryRepo = new GenericRepository<BlogCategory>(ooiContext);
                }
                return blogCategoryRepo;
            }
        }
        public GenericRepository<WebUser> WebUserRepo
        {
            get
            {
                if (this.webUserRepo == null)
                {
                    this.webUserRepo = new GenericRepository<WebUser>(ooiContext);
                }
                return webUserRepo;
            }
        }

        public GenericRepository<Interview> InterviewRepo
        {
            get
            {
                if (this.interviewRepo == null)
                {
                    this.interviewRepo = new GenericRepository<Interview>(ooiContext);
                }
                return interviewRepo;
            }
        }

        public void Save()
        {
            ooiContext.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ooiContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
