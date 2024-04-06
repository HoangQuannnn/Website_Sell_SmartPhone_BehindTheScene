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
    public class ManHinhConfig : IEntityTypeConfiguration<ManHinh>
    {
        public void Configure(EntityTypeBuilder<ManHinh> builder)
        {
            builder.ToTable("ManHinh");
            builder.HasKey(e => e.IdManHinh);
            builder.Property(e => e.MaManHinh).HasColumnType("varchar(50)");
            builder.Property(c => c.LoaiManHinh).HasColumnType("nvarchar(50)");
        }
    }
}
