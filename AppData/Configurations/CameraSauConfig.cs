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
    public class CameraSauConfig : IEntityTypeConfiguration<CameraSau>
    {
        public void Configure(EntityTypeBuilder<CameraSau> builder)
        {
            builder.ToTable("CameraSau");
            builder.HasKey(x => x.IdCameraSau);
            builder.Property(e => e.MaCameraSau).HasColumnType("varchar(50)");
            builder.Property(c => c.TrangThai).HasColumnType("int");
            

        }
    }
}
