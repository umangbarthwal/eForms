using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eform1.models
{
    public class FormDbContext : DbContext
    {
        public FormDbContext(DbContextOptions<FormDbContext> options) : base(options) { }   
        public DbSet<table_1> table_1s { get; set; }
        public DbSet<table_2> table_2s { get; set; }
        public DbSet<table_3> table_3s { get; set; }
    }
}
