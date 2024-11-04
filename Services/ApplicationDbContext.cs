﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using total_test_1.Models;

namespace total_test_1.Services
{
    public class ApplicationDbContext: IdentityDbContext<AdminUser>
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            builder.Entity<IdentityRole>().HasData(admin);
        }
    }
}
