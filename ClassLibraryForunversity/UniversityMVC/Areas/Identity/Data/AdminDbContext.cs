// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using UniversityMVC.Models;

namespace UniversityMVC.Areas.Identity.Data
{
    public class AdminDbContext:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public AdminDbContext()
        {

        }
        public AdminDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-71Q79TQ;Initial Catalog=UnversitydataAssingment;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Admin>(entity => entity.HasIndex(e => e.Email).IsUnique());
            builder.Entity<Admin>(entity => entity.HasIndex(e => e.PanNo).IsUnique());
            builder.Entity<Admin>(entity => entity.HasIndex(e => e.Password).IsUnique());
            builder.Entity<Admin>(entity => entity.HasIndex(e => e.ConfirmPassword).IsUnique());
        }
    }
}