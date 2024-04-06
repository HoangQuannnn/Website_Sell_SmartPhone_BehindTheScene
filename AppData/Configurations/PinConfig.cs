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
    public class PinConfig : IEntityTypeConfiguration<Pin>
    {
        public void Configure(EntityTypeBuilder<Pin> builder)
        {
            builder.ToTable("Pin");
            builder.HasKey(c => c.IdPin);
            builder.Property(c => c.LoaiPin).IsRequired().IsUnicode().HasMaxLength(50);
            
        }
    }
}
