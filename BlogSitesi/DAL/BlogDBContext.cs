using BlogSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BlogSitesi.ViewModels;

namespace BlogSitesi.DAL
{
    public class BlogDBContext : IdentityDbContext<Kullanici, Rol, int>
    {
        public BlogDBContext()
        {

        }

        public BlogDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Konu> Konular { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<MakaleKonu> MakaleKonular { get; set; }
        public DbSet<KullaniciKonu> KullaniciKonular { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 1, RoleId = 1 });
        }
    }
}
