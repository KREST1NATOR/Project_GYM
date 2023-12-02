using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project_GYM.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<ClientEntity> Clients { get; set; }
        public virtual DbSet<DiscountEntity> Discounts { get; set; }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }
        public virtual DbSet<GymEntity> Gyms { get; set; }
        public virtual DbSet<JobTitleEntity> JobTitles { get; set; }
        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public virtual DbSet<StatusEntity> Statuses { get; set; }
        public virtual DbSet<SubscriptionEntity> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionTypeEntity> SubscriptionTypes { get; set; }
        public virtual DbSet<TrainerEntity> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntity>()
                .HasMany(e => e.Subscription)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiscountEntity>()
                .Property(e => e.Value)
                .HasPrecision(53, 0);

            modelBuilder.Entity<DiscountEntity>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Discount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeEntity>()
                .Property(e => e.LengthOfService)
                .HasPrecision(53, 0);

            modelBuilder.Entity<GymEntity>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.Gym)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GymEntity>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Gym)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GymEntity>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Gym)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GymEntity>()
                .HasMany(e => e.Subscription)
                .WithRequired(e => e.Gym)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GymEntity>()
                .HasMany(e => e.Trainer)
                .WithRequired(e => e.Gym)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobTitleEntity>()
                .Property(e => e.Salary)
                .HasPrecision(53, 0);

            modelBuilder.Entity<JobTitleEntity>()
                .Property(e => e.WorkSchedule);

            modelBuilder.Entity<JobTitleEntity>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.JobTitle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.Price)
                .HasPrecision(53, 0);

            modelBuilder.Entity<ProductEntity>()
                .Property(e => e.Quantity)
                .HasPrecision(53, 0);

            modelBuilder.Entity<ProductCategoryEntity>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.ProductCategory)
                .HasForeignKey(e => e.ProductCategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StatusEntity>()
                .HasMany(e => e.Subscription)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubscriptionTypeEntity>()
                .Property(e => e.Cost)
                .HasPrecision(53, 0);

            modelBuilder.Entity<SubscriptionTypeEntity>()
                .Property(e => e.Term)
                .HasPrecision(53, 0);

            modelBuilder.Entity<SubscriptionTypeEntity>()
                .HasMany(e => e.Subscription)
                .WithRequired(e => e.SubscriptionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrainerEntity>()
                .Property(e => e.LengthOfService)
                .HasPrecision(53, 0);
        }
    }
}
