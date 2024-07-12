using BlogSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSitesi.DAL.EntityConfiguration
{
    public class KonuCFG : IEntityTypeConfiguration<Konu>
    {
        public void Configure(EntityTypeBuilder<Konu> builder)
        {
            builder.HasKey(x => x.KonuID);
            builder.Property(x => x.Adi).HasColumnType("varchar").HasMaxLength(50);
            builder.HasData(
                new Konu { KonuID = 1, Adi = "Felsefe" },
                new Konu { KonuID = 2, Adi = "Psikoloji" },
                new Konu { KonuID = 3, Adi = "Eğlence" },
                new Konu { KonuID = 4, Adi = "Eğitim" }
                );
        }
    }
}
