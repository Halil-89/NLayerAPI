using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NLayerWebUI.Entity.EntityConfiguration
{
    public class Configuration : IEntityTypeConfiguration<FaturaUst>
    {
        public void Configure(EntityTypeBuilder<FaturaUst> builder)
        {
            builder.HasKey(x => x.FaturaId);
            builder.Property(x => x.CariKod).IsRequired().HasMaxLength(30);
            builder.Property(x => x.FATIRS_NO).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Tip).IsRequired().HasMaxLength(1);
            builder.Property(x => x.TIPI).IsRequired().HasMaxLength(1);
            builder.Property(x => x.SIPARIS_TEST).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PLA_KODU).IsRequired().HasMaxLength(10);

        }
    }

    public class FatKalemConfiguration : IEntityTypeConfiguration<FatKalem>
    {
        public void Configure(EntityTypeBuilder<FatKalem> builder)
        {
            builder.HasKey(x => x.FaturaKalemId);
            builder.HasOne(x => x.Fatura).WithMany(x => x.FaturaKalems).HasForeignKey(x => x.FaturaId);
            builder.Property(x => x.StokKodu).IsRequired().HasMaxLength(30);
            builder.Property(x => x.STra_GCMIK).IsRequired().HasMaxLength(15);
            builder.Property(x => x.STra_NF).IsRequired().HasMaxLength(10);
            builder.Property(x => x.STra_BF).IsRequired().HasMaxLength(10);
            builder.Property(x => x.ProjeKodu).IsRequired().HasMaxLength(30);
            builder.Property(x => x.DEPO_KODU).IsRequired().HasMaxLength(10);

        }
    }
}
