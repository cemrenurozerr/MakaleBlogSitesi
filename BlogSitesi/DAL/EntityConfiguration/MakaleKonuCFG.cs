using BlogSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSitesi.DAL.EntityConfiguration
{
    public class MakaleKonuCFG : IEntityTypeConfiguration<MakaleKonu>
    {
        public void Configure(EntityTypeBuilder<MakaleKonu> builder)
        {
            builder.HasKey(x => x.MakaleKonuID);
            builder.HasOne(x => x.Makale).WithMany(x => x.MakaleKonular);
            builder.HasOne(x => x.Konu).WithMany(x => x.MakaleKonular);
            builder.HasData(
            new MakaleKonu()
             {
                MakaleID = 1,
                KonuID = 1,
                MakaleKonuID = 1
            },
            new MakaleKonu()
            {
                MakaleID = 2,
                KonuID = 1,
                MakaleKonuID = 2
            },
            new MakaleKonu()
            {
                MakaleID = 3,
                KonuID = 2,
                MakaleKonuID = 3
            },
            new MakaleKonu()
            {
                MakaleID = 4,
                KonuID = 2,
                MakaleKonuID = 4
            },
            new MakaleKonu()
            {
                MakaleID = 5,
                KonuID = 3,
                MakaleKonuID = 5
            },
            new MakaleKonu()
            {
                MakaleID = 6,
                KonuID = 4,
                MakaleKonuID = 6
            }
            );
        }
    }
}
