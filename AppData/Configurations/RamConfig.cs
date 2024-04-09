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
    public class RamConfig : IEntityTypeConfiguration<Ram>
    {
        public void Configure(EntityTypeBuilder<Ram> builder)
        {
            builder.ToTable("Ram");
            builder.HasKey(x => x.IdRam);
            builder.Property(e => e.MaRam).HasColumnType("varchar(50)");
            builder.Property(x => x.DungLuong).HasColumnType("varchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
