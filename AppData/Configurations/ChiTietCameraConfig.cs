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
    public class ChiTietCameraConfig : IEntityTypeConfiguration<ChiTietCamera>
    {
        public void Configure(EntityTypeBuilder<ChiTietCamera> builder)
        {
            builder.ToTable("ChiTietCamera");
            builder.HasKey(x => x.IdChiTietCamera);
            builder.HasOne(x => x.SanPhamChiTiet).WithMany(y => y.ChiTietCameras).HasForeignKey(g => g.IdSanPhamChiTiet);
            builder.HasOne(x => x.Camera).WithMany(y => y.ChiTietCameras).HasForeignKey(g => g.IdCamera);
        }
    }
}
