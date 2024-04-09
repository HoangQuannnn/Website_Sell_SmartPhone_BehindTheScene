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
    public class RomCofig: IEntityTypeConfiguration<Rom>
    {
        public void Configure(EntityTypeBuilder<Rom> builder)
        {
            builder.ToTable("Rom");
            builder.HasKey(x => x.IdRom);
            builder.Property(e => e.MaRom).HasColumnType("varchar(50)");
            builder.Property(x => x.DungLuong).HasColumnType("varchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
