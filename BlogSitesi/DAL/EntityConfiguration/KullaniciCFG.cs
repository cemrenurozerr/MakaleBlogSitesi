using BlogSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSitesi.DAL.EntityConfiguration
{
    public class KullaniciCFG : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            
            Kullanici kullanici = new Kullanici()
            {
                Id = 1,
                Ad = "Cemre",
                Soyad = "Özer",
                UserName = "cemre@admin.com",
                NormalizedUserName = "CEMRE@ADMİN.COM",
                Email = "cemre@admin.com",
                NormalizedEmail = "CEMRE@ADMİN.COM",
                EmailConfirmed = true,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };
            //Tabloda sifre hash'li oldugundan; sifre hashlandikten sonra gönderilir.
            PasswordHasher<Kullanici> passwordHasher = new PasswordHasher<Kullanici>();
            kullanici.PasswordHash = passwordHasher.HashPassword(kullanici, "Cemre_123");
            builder.HasData(kullanici);
            builder.Property(x => x.ProfilResmiYolu).HasColumnType("varchar").HasMaxLength(200);
                
        }
    }
}
