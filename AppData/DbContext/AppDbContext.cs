using App_Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App_Data.DbContext
{
    public class AppDbContext : IdentityDbContext<NguoiDung, ChucVu, string>
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Anh> Anh { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<GioHangChiTiet> GioHangChiTiets { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<KhuyenMaiChiTiet> KhuyenMaiChiTiets { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Rom> Roms { get; set; }
        public DbSet<CongSac> CongSacs { get; set; }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<Chip> Chips { get; set; }
        public DbSet<ManHinh> ManHinhs { get; set; }
        public DbSet<Pin> Pins { get; set; }
        public DbSet<TheNho> TheNhos { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<TheSim> TheSims { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<ChiTietCamera> ChiTietCameras { get; set; }
        public DbSet<TheSimDienThoai> TheSimDienThoais { get; set; }
        public DbSet<CameraSau> CameraSaus { get; set; }
        public DbSet<CameraTruoc> CameraTruocs { get; set; }
        public DbSet<Imei> Imeis { get; set; }
        public DbSet<ImeiChuaBan> ImeiChuaBans { get; set; }
        public DbSet<ImeiDaBan> ImeiDaBans { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public DbSet<PhuongThucThanhToanChiTiet> PhuongThucThanhToanChiTiets { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<SanPhamChiTiet> SanPhamChiTiets { get; set; }
        public DbSet<SanPhamYeuThich> SanPhamYeuThichs { get; set; }
        public DbSet<ThongTinGiaoHang> ThongTinGiaoHangs { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherNguoiDung> VoucherNguoiDungs { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6));
            //    }
            //}
            //Cấu hình tên bảng tùy chỉnh ở đây
            //modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
            //modelBuilder.Entity<ChucVu>().ToTable("ChucVu");
            modelBuilder.
               ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Website_Sell_SmartPhone_BehindTheScene;Integrated Security=True;TrustServerCertificate=true;");

        }
    }
}
