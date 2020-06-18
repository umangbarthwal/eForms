using Microsoft.EntityFrameworkCore;
using Eform1.models;
using System;

namespace Eform1.Data
{
    public class FormDbContext : DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<table_1>().ToTable("table_1s");
            modelBuilder.Entity<table_2>().ToTable("table_2s");
            modelBuilder.Entity<table_3>().ToTable("table_3s");
        }

        #region Properties
        public DbSet<table_1> table_1s { get; set; }
        public DbSet<table_2> table_2s { get; set; }
        public DbSet<table_3> table_3s { get; set; }
        #endregion
    }
}
