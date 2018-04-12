using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Domain
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
    : base(options)
        {
            this.Database.SetCommandTimeout(120);
        }
        public DbSet<User> Users { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 角色
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
