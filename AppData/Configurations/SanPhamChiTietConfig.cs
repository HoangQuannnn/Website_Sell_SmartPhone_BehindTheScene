using App_Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configurations
{
    public class SanPhamChiTietConfig : IEntityTypeConfiguration<SanPhamChiTiet>
    {
        public void Configure(EntityTypeBuilder<SanPhamChiTiet> builder)
        {
            builder.ToTable("SanPhamChiTiet");
            builder.HasKey(x => x.IdChiTietSp);

            builder.HasOne(x => x.Ram).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdRam);

            builder.HasOne(x => x.SanPham).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdSanPham);

            builder.HasOne(x => x.Rom).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdRom);

            builder.HasOne(x => x.CongSac).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdCongSac);

            builder.HasOne(x => x.Hang).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdHang);

            builder.HasOne(x => x.MauSac).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdMauSac);

            builder.HasOne(x => x.Chip).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdChip);

            builder.HasOne(x => x.ManHinh).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdManHinh); 
            
            builder.HasOne(x => x.TheNho).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdTheNho);
            
            builder.HasOne(x => x.Pin).WithMany(y => y.SanPhamChiTiets).
            HasForeignKey(c => c.IdPin);

            builder.Property(x => x.Ma).HasColumnType("varchar(50)");
            builder.Property(x => x.Day).HasColumnType("bit");
            builder.Property(x => x.NoiBat).HasColumnType("bit");
        }
    }
}
