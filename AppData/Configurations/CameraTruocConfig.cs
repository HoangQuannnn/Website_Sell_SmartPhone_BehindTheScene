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
    public class CameraTruocConfig : IEntityTypeConfiguration<CameraTruoc>
    {
        public void Configure(EntityTypeBuilder<CameraTruoc> builder)
        {
            builder.ToTable("CameraTruoc");
            builder.HasKey(x => x.IdCameraTruoc);
            builder.HasOne(x => x.SanPhamChiTiet).WithMany(y => y.CameraTruocs).HasForeignKey(g => g.IdSanPhamChiTiet);

        }
    }
}
