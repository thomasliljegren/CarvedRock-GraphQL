using CarvedRock.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarvedRock.DataAccess.DAL
{
    public class CarvedRockContext : DbContext
    {
        public CarvedRockContext(DbContextOptions<CarvedRockContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

    }
}
