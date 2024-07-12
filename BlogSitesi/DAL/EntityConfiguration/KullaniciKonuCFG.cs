using BlogSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSitesi.DAL.EntityConfiguration
{
    public class KullaniciKonuCFG : IEntityTypeConfiguration<KullaniciKonu>
    {
        public void Configure(EntityTypeBuilder<KullaniciKonu> builder)
        {
            builder.HasKey(x => x.KullaniciKonuID);
            builder.HasOne(x => x.Kullanici).WithMany(x => x.TakipEdilenler);
            builder.HasOne(x => x.Konu).WithMany(x => x.TakipEdilenler);
        }
    }
}
