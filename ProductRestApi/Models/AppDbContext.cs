using Microsoft.EntityFrameworkCore;
using ProductRestApi.Classes;

namespace ProductRestApi.Models

{
    public class AppDbContext : DbContext
    {

      public AppDbContext(DbContextOptions options) 
            : base(options)
        {
        }  

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .Property(p => p.ProductId)
        .ValueGeneratedOnAdd();

            //Create the products


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Shoes",
                    ProductDescription = "Are shoes Mate",
                    ProductPrice = 43f,
                    ProductDiscount = 0.20f,
                    proType = ProductType.Product
                }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 2,
                    ProductName = "Massages",
                    ProductDescription = "Is massage Mate",
                    ProductPrice = 20f,
                    ProductDiscount = 0.0f,
                    proType = ProductType.Service
                });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 3,
                    ProductName = "football",
                    ProductDescription = "Fuchiball Fuchiball ronaldhino",
                    ProductPrice = 15f,
                    ProductDiscount = 0.15f,
                    proType = ProductType.Product,
                });

            modelBuilder.Entity<Product>().HasData(
             new Product
             {
                 ProductId = 4,
                 ProductName = "Dont know",
                 ProductDescription = "Bruh",
                 ProductPrice = 10f,
                 ProductDiscount = 0.0f,
                 proType = ProductType.Other
             }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 5,
                    ProductName = "Computer",
                    ProductDescription = "Unix system",
                    ProductPrice = 250f,
                    ProductDiscount = 0.30f,
                    proType = ProductType.Product
                }
                );
        }
    }
}
