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
    public class TheSimDienThoaiConfig : IEntityTypeConfiguration<TheSimDienThoai>
    {
        public void Configure(EntityTypeBuilder<TheSimDienThoai> builder)
        {
            builder.ToTable("TheSimDienThoai");
            builder.HasKey(x => x.IdTheSimDienThoai);
            builder.HasOne(x => x.SanPhamChiTiet).WithMany(x => x.TheSimDienThoais).HasForeignKey(g => g.IdSanPhamChiTiet);
            builder.HasOne(x => x.Thesim).WithMany(x => x.TheSimDienThoais).HasForeignKey(g => g.IdTheSim);
        }
    }
}
