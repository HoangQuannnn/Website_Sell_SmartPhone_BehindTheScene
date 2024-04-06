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
    public class ImeiChuaBanConfig : IEntityTypeConfiguration<ImeiChuaBan>
    {
        public void Configure(EntityTypeBuilder<ImeiChuaBan> builder)
        {
            builder.ToTable("ImeiChuaBan");
            builder.HasKey(x => x.IdImeiChuaBan);
            builder.Property(c => c.SoImei).HasColumnType("varchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
            builder.HasOne(c => c.GioHangChiTiet).WithMany(c => c.ImeiChuaBans).HasForeignKey(c => c.IdGioHangChiTiet);
        }
    }
}
