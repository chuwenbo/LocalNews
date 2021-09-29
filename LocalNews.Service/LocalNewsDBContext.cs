using LocalNews.Service.Entity;
using LocalNews.Service.EntityBuilder;
using Microsoft.EntityFrameworkCore;
using System;

namespace LocalNews.Service
{
    public class LocalNewsDBContext: DbContext
    {
        public LocalNewsDBContext(DbContextOptions options) : base(options) {
            Database.SetCommandTimeout(60 * 60 * 10);
        }

        public DbSet<LocalNews_Main> LocalNews_Main { get; set; }
        public DbSet<LocalNews_Content> LocalNews_Content { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LocalNews_Main>(LocalNews_Main_Builder.Build);
            modelBuilder.Entity<LocalNews_Content>(LocalNews_Content_Builder.Build);

            base.OnModelCreating(modelBuilder);
        }
    }
}
