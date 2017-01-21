using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mlp.Blog.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mlp.Blog.Core.Domain.Page;

namespace Mlp.Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private const string _connectionDb = @"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;";
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<PgMenu> PgMenus { get; set; }

        public DbSet<PgTypeMenu> PgTypeMenus { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionDb);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class TemporaryDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {private const string _connectionDb = @"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;";
        public ApplicationDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            builder.UseSqlServer(_connectionDb);
            return new ApplicationDbContext(builder.Options);
        }

        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(options.ApplicationBasePath);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
