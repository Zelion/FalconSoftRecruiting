using Bogus;
using Bogus.Extensions;
using ExerciseA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseA.Implementation.DbContexts
{
    public class ExerciseAContext : DbContext
    {

        public ExerciseAContext(DbContextOptions<ExerciseAContext> options) : base(options)
        {

        }

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        //public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Order
            modelBuilder.Entity<Order>()
               .Property(p => p.CustomerName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Order>()
                .HasKey(c => c.Id);

            // Order Detail
            modelBuilder.Entity<OrderDetail>()
                .HasOne(p => p.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<OrderDetail>()
               .Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<OrderDetail>()
                .HasKey(c => c.Id);

            // Product
            modelBuilder.Entity<Product>()
               .Property(p => p.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Product>()
               .Property(p => p.Price).IsRequired();
            modelBuilder.Entity<Product>()
                .HasKey(c => c.Id);

            //// User Info
            //modelBuilder.Entity<UserInfo>()
            //   .Property(p => p.FirstName).HasMaxLength(30);
            //modelBuilder.Entity<UserInfo>()
            //   .Property(p => p.LastName).HasMaxLength(30);
            //modelBuilder.Entity<UserInfo>()
            //   .Property(p => p.UserName).HasMaxLength(30).IsRequired();
            //modelBuilder.Entity<UserInfo>()
            //   .Property(p => p.Email).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<UserInfo>()
            //   .Property(p => p.Password).HasMaxLength(20).IsRequired();
            //modelBuilder.Entity<UserInfo>()
            //    .HasKey(c => c.Id);


            // Seed using Bogus
            //  Products
            var productIds = 1;
            var product = new Faker<Product>()
                .RuleFor(m => m.Id, f => productIds++)
                .RuleFor(m => m.Name, f => f.Commerce.ProductName())
                .RuleFor(m => m.Price, f => f.Random.Int(1, 300));
            var products = product.GenerateBetween(20, 20);
            modelBuilder
                .Entity<Product>()
                .HasData(products.ToArray());

            //  Orders
            var orderIds = 1;
            var order = new Faker<Order>()
                .RuleFor(m => m.Id, f => orderIds++)
                .RuleFor(m => m.CustomerName, f => f.Person.FullName)
                .RuleFor(m => m.CreatedDate, f => f.Date.Recent(7));
            var orders = order.GenerateBetween(50, 50);
            modelBuilder
                .Entity<Order>()
                .HasData(orders.ToArray());

            //  OrderDetails
            var orderDetailIds = 1;
            var orderDetail = new Faker<OrderDetail>()
                .RuleFor(m => m.Id, f => orderDetailIds++)
                .RuleFor(m => m.Quantity, f => f.Random.Int(1, 200))
                .RuleFor(m => m.OrderId, f => f.PickRandom(orders).Id)
                .RuleFor(m => m.ProductId, f => f.PickRandom(products).Id);
            modelBuilder
                .Entity<OrderDetail>()
                .HasData(orderDetail.GenerateBetween(20, 20).ToArray());

            ////  Users Info
            //var userInfoIds = 1;
            //var userInfo = new Faker<UserInfo>()
            //    .RuleFor(m => m.Id, f => userInfoIds++)
            //    .RuleFor(m => m.FirstName, f => f.Name.FirstName())
            //    .RuleFor(m => m.LastName, f => f.Name.LastName())
            //    .RuleFor(m => m.UserName, f => f.Internet.UserName())
            //    .RuleFor(m => m.Email, f => f.Internet.Email())
            //    .RuleFor(m => m.Password, f => f.Internet.Password())
            //    .RuleFor(m => m.CreatedDate, f => f.Date.Recent(7));
            //modelBuilder
            //    .Entity<UserInfo>()
            //    .HasData(userInfo.GenerateBetween(5, 5).ToArray());
        }
    }
}
