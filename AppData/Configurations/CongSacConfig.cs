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
    public class CongSacConfig: IEntityTypeConfiguration<CongSac>
    {
        public void Configure(EntityTypeBuilder<CongSac> builder)
        {
            builder.ToTable("CongSac");
            builder.HasKey(x => x.IdCongSac);
            builder.Property(x => x.LoaiCongSac).HasColumnType("varchar(100)");
            builder.Property(x => x.TrangThai).HasColumnType("varchar(50)");
        }
    }
}
