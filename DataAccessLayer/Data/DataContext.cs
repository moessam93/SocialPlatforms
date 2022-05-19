using DataAccessLayer.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SocialPlatformsAPI.Data.Entities
{
    public class DataContext:IdentityDbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SocialPlatform> socialPlatforms { get; set; }
        public DbSet<Languages> languages { get; set; }
        public DbSet<SocialPlatformTranslations> SocialPlatformTranslations { get; set; }
        public DbSet<Users> users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SocialPlatformTranslations>().HasKey(x => new { x.SocialPlatformId, x.LanguageId });

            modelBuilder.Entity<SocialPlatform>()
                .HasMany(platform => platform.Translations)
                .WithOne(translation => translation.SocialPlatform);

            //modelBuilder.Entity<SocialPlatformTranslations>()
            //    .HasOne(translation=>translation.Language)
            //    .WithOne(language=>language.Translation);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var dbConnectionInfo = builder.Build().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            optionsBuilder.UseSqlServer(dbConnectionInfo);
        }

    }
    
}
