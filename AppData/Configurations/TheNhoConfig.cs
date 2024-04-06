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
    public class TheNhoConfig : IEntityTypeConfiguration<TheNho>
    {
        public void Configure(EntityTypeBuilder<TheNho> builder)
        {
            builder.ToTable("TheNho");
            builder.HasKey(c => c.IdTheNho);
            builder.Property(c => c.LoaiTheNho).IsRequired().IsUnicode().HasMaxLength(50);
            
        }
    }
}
