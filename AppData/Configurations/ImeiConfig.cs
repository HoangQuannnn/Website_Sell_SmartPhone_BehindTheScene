using App_Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Configurations
{
    public class ImeiConfig : IEntityTypeConfiguration<Imei>
    {
        public void Configure(EntityTypeBuilder<Imei> builder)
        {
            builder.ToTable("Imei");
            builder.HasKey(x => x.IdImei);
            builder.Property(c => c.SoImei).HasColumnType("varchar(50)");
            builder.Property(c => c.MaVach).HasColumnType("nvarchar(1000)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
            builder.HasOne(c => c.SanPhamChiTiet).WithMany(c => c.Imeis).HasForeignKey(c => c.IdSanPhamChiTiet);
        }
    }
}
