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
    public class TheSimConfig : IEntityTypeConfiguration<TheSim>
    {
        public void Configure(EntityTypeBuilder<TheSim> builder)
        {
            builder.ToTable("TheSim");
            builder.HasKey(x=>x.IdTheSim);
            builder.Property(x=>x.TrangThai).HasColumnType("int");

        }
    }
}
