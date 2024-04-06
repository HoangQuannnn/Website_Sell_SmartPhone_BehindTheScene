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
    public class ChipConfig : IEntityTypeConfiguration<Chip>
    {
        public void Configure(EntityTypeBuilder<Chip> builder)
        {
            builder.ToTable("Chip");
            builder.HasKey(e => e.IdChip);
            builder.Property(e => e.MaChip).HasColumnType("varchar(50)");
            builder.Property(c => c.TenChip).HasColumnType("nvarchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
        }
    }
}
