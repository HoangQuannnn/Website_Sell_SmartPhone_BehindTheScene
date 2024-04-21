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
    public class HangConfig : IEntityTypeConfiguration<Hang>
    {
        public void Configure(EntityTypeBuilder<Hang> builder)
        {
            builder.ToTable("Hang");
            builder.HasKey(e => e.IdHang);
            builder.Property(e => e.MaHang).HasColumnType("varchar(50)");
            builder.Property(c => c.TenHang).HasColumnType("nvarchar(1000)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
