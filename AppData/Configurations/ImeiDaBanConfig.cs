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
    public class ImeiDaBanConfig : IEntityTypeConfiguration<ImeiDaBan>
    {
        public void Configure(EntityTypeBuilder<ImeiDaBan> builder)
        {
            builder.ToTable("ImeiDaBan");
            builder.HasKey(x => x.IdImeiDaBan);
            builder.Property(c => c.SoImei).HasColumnType("varchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
            builder.HasOne(c => c.HoaDonChiTiet).WithMany(c => c.ImeiDaBans).HasForeignKey(c => c.IdHoaDonChiTiet);
        }
    }
}
