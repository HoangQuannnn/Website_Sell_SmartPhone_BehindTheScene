using App_Data.Models;
using App_Data.ViewModels.GioHangChiTiet;
using App_Data.ViewModels.MauSac;
using App_Data.ViewModels.SanPhamChiTiet.SanPhamDTO;
using App_Data.ViewModels.SanPhamChiTietDTO;
using App_Data.ViewModels.SanPhamChiTietViewModel;
using App_Data.ViewModels.Voucher;
using App_Data.ViewModels.XuatXu;
using AutoMapper;

using App_Data.ViewModels.VoucherNguoiDung;

using App_Data.ViewModels.KhuyenMaiChiTietDTO;

using App_Data.ViewModels.HoaDonChiTietDTO;
using App_Data.ViewModels.ChiTietCameraDTO;

using static Peg.Base.PegBaseParser;


using App_Data.ViewModels.ThongTinGHDTO;
using App_Data.ViewModels.HoaDon;
using App_Data.DbContext;
using App_Data.ViewModels.SanPhamYeuThichDTO;
using App_Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using App_Data.ViewModels.HangDTO;
using App_Data.ViewModels.RamDTO;
using App_Data.ViewModels.RomDTO;
using App_Data.ViewModels.ManHinhDTO;
using App_Data.ViewModels.CongSacDTO;
using App_Data.ViewModels.PinDTO;
using App_Data.ViewModels.ChipDTO;
using App_Data.ViewModels.TheNhoDTO;
using App_Data.ViewModels.ChiTietCameraDTO;
using App_Data.ViewModels.TheSimDTO;
using App_Data.ViewModels.CameraSauDTO;
using App_Data.ViewModels.CameraTruocDTO;

namespace App_Api.Helpers.Mapping
{
    public class MappingProfiles : Profile
    {
        private readonly AppDbContext appContext = new AppDbContext();
        private readonly DanhGiaRepo _danhGiaRepo = new DanhGiaRepo();

        private string GetCameraSauResolution(SanPhamChiTiet src)
        {
            List<string> resolutions = new List<string>
    {
        src.CameraSau.DoPhanGiaiCamera1,
        src.CameraSau.DoPhanGiaiCamera2,
        src.CameraSau.DoPhanGiaiCamera3,
        src.CameraSau.DoPhanGiaiCamera4,
        src.CameraSau.DoPhanGiaiCamera5
    };

            // Loại bỏ các giá trị null hoặc rỗng
            resolutions.RemoveAll(string.IsNullOrEmpty);

            // Trả về chuỗi các độ phân giải nếu có
            return string.Join(" - ", resolutions);
        }
        public MappingProfiles()
        {
            CreateMap<HoaDon, HoaDonDTO>();
            CreateMap<HoaDonDTO, HoaDon>();
            CreateMap<HoaDonChiTiet, HoaDonChiTietTaiQuay>();
            CreateMap<MauSacDTO, MauSac>();
            CreateMap<VoucherDTO, Voucher>().ReverseMap();

            CreateMap<SanPhamTableDTO, SanPhamChiTiet>()
                .ForMember(
                dest => dest.IdChiTietSp, opt => opt.MapFrom(x => x.IdProductTableDTO))
                .ForMember(
                dest => dest.SoLuongTon, opt => opt.MapFrom(x => x.SoLuongTon))
                .ForMember(
                dest => dest.GiaBan, opt => opt.MapFrom(x => x.GiaBan));

            CreateMap<VoucherNguoiDungDTO, VoucherNguoiDung>().ReverseMap()
                .ForMember(
                dest => dest.TenVoucher, opt => opt.MapFrom(x => x.Vouchers.TenVoucher))
                .ForMember(
                dest => dest.DieuKien, opt => opt.MapFrom(x => x.Vouchers.DieuKien))
                .ForMember(
                dest => dest.LoaiHinhUuDai, opt => opt.MapFrom(x => x.Vouchers.LoaiHinhUuDai))
                .ForMember(
                dest => dest.SoLuong, opt => opt.MapFrom(x => x.Vouchers.SoLuong))
                   .ForMember(
                dest => dest.MucUuDai, opt => opt.MapFrom(x => x.Vouchers.MucUuDai))
                      .ForMember(
                dest => dest.NgayBatDau, opt => opt.MapFrom(x => x.Vouchers.NgayBatDau))
                       .ForMember(
                dest => dest.NgayKetThuc, opt => opt.MapFrom(x => x.Vouchers.NgayKetThuc))
                       .ForMember(
                dest => dest.NgayTao, opt => opt.MapFrom(x => x.Vouchers.NgayTao))
                         .ForMember(
                dest => dest.SoLuong, opt => opt.MapFrom(x => x.Vouchers.SoLuong))
            .ForMember(
                dest => dest.MaVoucher, opt => opt.MapFrom(x => x.Vouchers.MaVoucher))
            .ForMember(
                dest => dest.NgayNhan, opt => opt.MapFrom(x => x.NgayNhan))
            ;

            CreateMap<GioHangChiTiet, SanPhamGioHangViewModel>()
                .ForMember(
                    dest => dest.IdSanPhamChiTiet,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.IdChiTietSp)
                )
                .ForMember(
                    dest => dest.IdGioHangChiTiet,
                    opt => opt.MapFrom(src => src.IdGioHangChiTiet)
                )
                .ForMember(
                    dest => dest.TenSanPham,
                    opt => opt.MapFrom(src => $"{src.SanPhamChiTiet.SanPham.TenSanPham} {src.SanPhamChiTiet.MauSac.TenMauSac} {src.SanPhamChiTiet.Ram.DungLuong} {src.SanPhamChiTiet.Rom.DungLuong}")
                )
                .ForMember(
                    dest => dest.SoLuong,
                    opt => opt.MapFrom(src => src.Soluong)
                )
                .ForMember(
                    dest => dest.GiaSanPham,
                    opt => opt.MapFrom(src => src.GiaBan)
                )
                .ForMember(
                    dest => dest.TenHang,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.Hang.TenHang)
                )
                .ForMember(
                    dest => dest.Anh,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.Anh.OrderBy(a => a.NgayTao).Select(x => x.Url).FirstOrDefault())
                );

            CreateMap<GioHangChiTiet, GioHangChiTietDTO>()
                 .ForMember(
                    dest => dest.TenSanPham,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.SanPham.TenSanPham)
                ).ForMember(
                    dest => dest.TenMauSac,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.MauSac.TenMauSac)
                ).ForMember(
                    dest => dest.DungLuongRam,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.Ram.DungLuong)
                ).ForMember(
                    dest => dest.DungLuongRom,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.Rom.DungLuong)
                ).ForMember(
                dest => dest.TenHang,
                opt => opt.MapFrom(src => src.SanPhamChiTiet.Hang.TenHang)
                ).ForMember(
                dest => dest.TrangThaiSanPham,
                opt => opt.MapFrom(src => src.SanPhamChiTiet.TrangThai)
                ).ForMember(
                dest => dest.LinkAnh,
                opt => opt.MapFrom(src => src.SanPhamChiTiet.Anh.OrderBy(a => a.NgayTao).Select(x => x.Url).ToList())
                );
            CreateMap<GioHangChiTietDTOCUD, GioHangChiTiet>().ReverseMap();

            CreateMap<SanPhamChiTiet, SanPhamChiTietExcelViewModel>()
                .ForMember(
                        dest => dest.SanPham,
                        opt => opt.MapFrom(src => src.SanPham.TenSanPham)
                )
                .ForMember(
                        dest => dest.Hang,
                        opt => opt.MapFrom(src => src.Hang.TenHang)
                    )
                .ForMember(
                        dest => dest.TheNho,
                        opt => opt.MapFrom(src => $"{src.TheNho.LoaiTheNho}")
                    )
                .ForMember(
                        dest => dest.Ram,
                        opt => opt.MapFrom(src => src.Ram.DungLuong)
                    )
                .ForMember(
                        dest => dest.MauSac,
                        opt => opt.MapFrom(src => src.MauSac.TenMauSac)
                    )
                .ForMember(
                        dest => dest.Rom,
                        opt => opt.MapFrom(src => src.Rom.DungLuong)
                    )
                .ForMember(
                        dest => dest.CongSac,
                        opt => opt.MapFrom(src => src.CongSac.LoaiCongSac)
                    )
                .ForMember(
                        dest => dest.ManHinh,
                        opt => opt.MapFrom(src => $"{src.ManHinh.LoaiManHinh}")
                    )
                .ForMember(
                        dest => dest.Chip,
                        opt => opt.MapFrom(src => src.Chip.TenChip)
                    )
                .ForMember(
                        dest => dest.Ma,
                        opt => opt.MapFrom(src => src.Ma)
                    )
                .ForMember(
                        dest => dest.DanhSachAnh,
                        opt => opt.MapFrom(src => string.Join(",", src.Anh.Where(a => a.TrangThai == 0).OrderBy(a => a.NgayTao).Select(a => a.Url)))
                    )
                .ForMember(
                        dest => dest.Pin,
                        opt => opt.MapFrom(src => $"{src.Pin.LoaiPin} {src.Pin.DungLuong}")

                    )
                .ForMember(
                        dest => dest.TrangThaiKhuyenMai,
                        opt => opt.MapFrom(src => src.TrangThaiSale)
                    )
                .ForMember(
                        dest => dest.NgayTao,
                        opt => opt.MapFrom(src => src.NgayTao.GetValueOrDefault().ToString())
                    )
                ;
            CreateMap<HoaDonDTO, HoaDon>().ReverseMap();
            CreateMap<HoaDon, HoaDonViewModel>().ForMember(
                        dest => dest.TenNguoiNhan,
                        opt => opt.MapFrom(src => src.ThongTinGiaoHang.TenNguoiNhan)
                    ).ForMember(
                        dest => dest.SDT,
                        opt => opt.MapFrom(src => src.ThongTinGiaoHang.SDT)
                    ).ForMember(
                        dest => dest.DiaChi,
                        opt => opt.MapFrom(src => src.ThongTinGiaoHang.DiaChi)
                    );
            CreateMap<ThongTinGHDTO, ThongTinGiaoHang>().ReverseMap();
            //CreateMap<ThongTinGiaoHang, ThongTinGHDTO>();
            CreateMap<HoaDonChiTietDTO, HoaDonChiTiet>().ReverseMap();
            CreateMap<HoaDonChiTiet, HoaDonChiTietViewModel>()
                .ForMember(
                dest => dest.TenSanPham,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.SanPham.TenSanPham)
                ).ForMember(
                    dest => dest.TenMauSac,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.MauSac.TenMauSac)
                ).ForMember(
                    dest => dest.DungLuongRam,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.Ram.DungLuong)
                ).ForMember(
                    dest => dest.DungLuongRom,
                    opt => opt.MapFrom(src => src.SanPhamChiTiet.Rom.DungLuong)
                ).ForMember(
                dest => dest.TenNguoiNhan,
                opt => opt.MapFrom(src => src.HoaDon.ThongTinGiaoHang.TenNguoiNhan)
                ).ForMember(
                dest => dest.MaVoucher,
                opt => opt.MapFrom(src => src.HoaDon.Voucher.MaVoucher)
                );


            CreateMap<SanPhamChiTiet, SanPhamChiTietDTO>()
                .ForMember(
                        dest => dest.DanhSachAnh,
                        opt => opt.MapFrom(src => src.Anh.Where(a => a.TrangThai == 0).OrderBy(a => a.NgayTao).Select(x => x.Url))
                )
                .ForMember(
                        dest => dest.FullName,
                        opt => opt.MapFrom(src => $"{src.SanPham.TenSanPham} {src.Ram.DungLuong}/{src.Rom.DungLuong} {src.MauSac.TenMauSac}")
                )
                .ForMember(
                        dest => dest.TrangThaiKhuyenMai,
                        opt => opt.MapFrom(src => src.TrangThaiSale == 1 ? true : false)
                )
                .ReverseMap()
                .ForMember(
                        dest => dest.TrangThaiSale,
                        opt => opt.MapFrom(src => src.TrangThaiKhuyenMai ? 1 : 0)
                    )
                ;

            //CreateMap<List<SanPhamChiTiet>, DanhSachGiayViewModel>()
            //    .ConvertUsing<SanPhamChiTietToListItemViewModelConverter>();

            CreateMap<SanPhamChiTiet, SanPhamDanhSachViewModel>();

            CreateMap<SanPhamChiTiet, SanPhamChiTietViewModel>()
                .ForMember(
                        dest => dest.SanPham,
                        opt => opt.MapFrom(src => src.SanPham.TenSanPham)
                )
                .ForMember(
                        dest => dest.Hang,
                        opt => opt.MapFrom(src => src.Hang.TenHang)
                    )
                .ForMember(
                        dest => dest.SoLuongDaBan,
                        opt => opt.MapFrom(src => src.SoLuongDaBan)
                    )
                .ForMember(
                        dest => dest.NgayTao,
                        opt => opt.MapFrom(src => src.NgayTao.GetValueOrDefault().ToString("dd-MM-yyyy"))
                    )
                .ForMember(
                        dest => dest.Ram,
                        opt => opt.MapFrom(src => src.Ram.DungLuong)
                    )
                .ForMember(
                        dest => dest.MauSac,
                        opt => opt.MapFrom(src => src.MauSac.TenMauSac)
                    )
                .ForMember(
                        dest => dest.Rom,
                        opt => opt.MapFrom(src => src.Rom.DungLuong)
                    )
                .ForMember(
                        dest => dest.CongSac,
                        opt => opt.MapFrom(src => src.CongSac.LoaiCongSac)
                    )
               .ForMember(
                    dest => dest.ManHinh,
                    opt => opt.MapFrom(src => $"{src.ManHinh.LoaiManHinh} {src.ManHinh.KichThuoc}\"")
                )
                 .ForMember(
                        dest => dest.TheNho,
                        opt => opt.MapFrom(src => $"{src.TheNho.LoaiTheNho} {src.TheNho.DungLuong}")
                    )

                .ForMember(
    dest => dest.TheSim,
    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.TheSim.LoaiTheSim2) ? $"{src.TheSim.LoaiTheSim1} - {src.TheSim.LoaiTheSim2}" : src.TheSim.LoaiTheSim1)
)


.ForMember(
    dest => dest.CameraTruoc,
    opt => opt.MapFrom(src =>
        !string.IsNullOrEmpty(src.CameraTruoc.DoPhanGiaiCamera2) ?
        $"{src.CameraTruoc.DoPhanGiaiCamera1} - {src.CameraTruoc.DoPhanGiaiCamera2}" :
        src.CameraTruoc.DoPhanGiaiCamera1
    )
)



.ForMember(
    dest => dest.CameraSau,
    opt => opt.MapFrom(src => GetCameraSauResolution(src))
)


                .ForMember(
                        dest => dest.Chip,
                        opt => opt.MapFrom(src => src.Chip.TenChip)
                    )
              .ForMember(
                        dest => dest.Pin,
                        opt => opt.MapFrom(src => $"{src.Pin.LoaiPin} {src.Pin.DungLuong}")

                    )
                .ForMember(
                        dest => dest.ListTenAnh,
                        opt => opt.MapFrom(src => src.Anh.Where(an => an.TrangThai == 0).OrderBy(x => x.NgayTao).Select(x => x.Url).ToList())
                    );

            CreateMap<SanPhamChiTiet, ItemShopViewModel>()
                .ForMember(
                        dest => dest.Anh,
                        opt => opt.MapFrom(src => src.Anh!.Where(a => a.TrangThai == 0).OrderBy(x => x.NgayTao).FirstOrDefault()!.Url)
                    )
                .ForMember(
                        dest => dest.IdChiTietSp,
                        opt => opt.MapFrom(src => src.IdChiTietSp)
                    )
                .ForMember(
                        dest => dest.GiaGoc,
                        opt => opt.MapFrom(src => src.GiaBan)
                    )
                .ForMember(
                        dest => dest.MaSanPham,
                        opt => opt.MapFrom(src => src.Ma)
                    )
                .ForMember(
                        dest => dest.GiaThucTe,
                        opt => opt.MapFrom(src => src.GiaThucTe)
                    )
                .ForMember(
                        dest => dest.GiaKhuyenMai,
                        opt => opt.MapFrom(src => src.GiaThucTe)
                    )
                .ForMember(
                        dest => dest.Hang,
                        opt => opt.MapFrom(src => src.Hang.TenHang)
                    )
                .ForMember(
                        dest => dest.TenSanPham,
                        opt => opt.MapFrom(src => src.SanPham.TenSanPham)
                    )
                .ForMember(
                        dest => dest.MoTaNgan,
                        opt => opt.MapFrom(src => "Sản phẩm chính hãng")
                    )
                .ForMember(
                        dest => dest.Ram,
                        opt => opt.MapFrom(src => src.Ram.DungLuong)
                    )
                .ForMember(
                        dest => dest.Rom,
                        opt => opt.MapFrom(src => src.Rom.DungLuong)
                    )
                .ForMember(
                        dest => dest.MauSac,
                        opt => opt.MapFrom(src => src.MauSac.TenMauSac)
                    )
                .ForMember(
                        dest => dest.SoSao,
                        opt => opt.MapFrom(src => _danhGiaRepo.SoSaoTB(src.IdChiTietSp!).Result)
                    )
                .ForMember(
                        dest => dest.SoLanDanhGia,
                        opt => opt.MapFrom(src => _danhGiaRepo.GetTongSoDanhGia(src.IdChiTietSp!).Result)
                    )
                .ForMember(
                        dest => dest.GiaMin,
                        opt => opt.MapFrom(src => appContext.SanPhamChiTiets
                        .Where(x =>
                        x.TrangThai == 0 &&
                        x.IdHang == src.IdHang &&
                        x.IdSanPham == src.IdSanPham &&
                        x.IdRam == src.IdRam &&
                        x.IdRom == src.IdRom &&
                        x.IdManHinh == src.IdManHinh &&
                        x.IdCongSac == src.IdCongSac &&
                        x.IdTheNho == src.IdTheNho &&
                        x.IdPin == src.IdPin &&
                        x.IdChip == src.IdChip
                        )
                        .Select(x => x.GiaThucTe).Min()
                        )
                    )
                 .ForMember(
                        dest => dest.GiaMax,
                        opt => opt.MapFrom(src => appContext.SanPhamChiTiets
                        .Where(x =>
                        x.TrangThai == 0 &&
                        x.IdHang == src.IdHang &&
                        x.IdSanPham == src.IdSanPham &&
                        x.IdRam == src.IdRam &&
                        x.IdRom == src.IdRom &&
                        x.IdManHinh == src.IdManHinh &&
                        x.IdCongSac == src.IdCongSac &&
                        x.IdTheNho == src.IdTheNho &&
                        x.IdPin == src.IdPin &&
                        x.IdChip == src.IdChip
                        )
                        .Select(x => x.GiaThucTe).Max()
                        )
                    )
                 .ForMember(
                        dest => dest.LstMauSac,
                        opt => opt.MapFrom(src => appContext.SanPhamChiTiets
                        .Where(x =>
                        x.TrangThai == 0 &&
                        x.IdHang == src.IdHang &&
                        x.IdSanPham == src.IdSanPham &&
                        x.IdRam == src.IdRam &&
                        x.IdRom == src.IdRom &&
                        x.IdManHinh == src.IdManHinh &&
                        x.IdCongSac == src.IdCongSac &&
                        x.IdTheNho == src.IdTheNho &&
                        x.IdPin == src.IdPin &&
                        x.IdChip == src.IdChip
                        )
                        .Select(sp => new SelectListItem()
                        {
                            Text = sp.MauSac.TenMauSac,
                            Value = sp.MauSac.IdMauSac!.ToString()
                        })
                        .Distinct()
                        .ToList()
                        )
                    )
                ;
            CreateMap<SanPhamChiTiet, ItemDetailViewModel>()
                .ForMember(
                        dest => dest.Anh,
                        opt => opt.MapFrom(src => src.Anh.Where(x => x.TrangThai == 0).OrderBy(a => a.NgayTao)!.FirstOrDefault()!.Url)
                    )
                .ForMember(
                        dest => dest.MoTaSanPham,
                        opt => opt.MapFrom(src => src.MoTa)
                    )
                .ForMember(
                        dest => dest.IdChiTietSp,
                        opt => opt.MapFrom(src => src.IdChiTietSp)
                    )
                .ForMember(
                        dest => dest.GiaGoc,
                        opt => opt.MapFrom(src => src.GiaBan)
                    )
                .ForMember(
                        dest => dest.GiaKhuyenMai,
                        opt => opt.MapFrom(src => src.GiaThucTe)
                    )
                .ForMember(
                        dest => dest.SoSao,
                        opt => opt.MapFrom(src => 5)
                    )
                  .ForMember(
                        dest => dest.Hang,
                        opt => opt.MapFrom(src => src.Hang.TenHang)
                    )
                .ForMember(
                        dest => dest.TenSanPham,
                        opt => opt.MapFrom(src => src.SanPham.TenSanPham)
                    )
                .ForMember(
                        dest => dest.MoTaNgan,
                        opt => opt.MapFrom(src => "Sản phẩm chính hãng")
                    )
                .ForMember(
                        dest => dest.SoLanDanhGia,
                        opt => opt.MapFrom(src => 32)
                    )
                 .ForMember(
                        dest => dest.DanhSachAnh,
                        opt => opt.MapFrom(src => src.Anh.Where(x => x.TrangThai == 0).OrderBy(x => x.NgayTao).Select(a => a.Url).ToList())
                    )
                 .ForMember(
                        dest => dest.MauSac,
                        opt => opt.MapFrom(src => src.MauSac.TenMauSac)
                    )
                 .ForMember(
                        dest => dest.Ram,
                        opt => opt.MapFrom(src => src.Ram.DungLuong)
                    )
                .ForMember(
                        dest => dest.Rom,
                        opt => opt.MapFrom(src => src.Rom.DungLuong)
                    )
                 .ForMember(
                        dest => dest.SoLuotYeuThich,
                        opt => opt.MapFrom(src => src.SanPhamYeuThichs.ToList().Count)
                    )
                 .ForMember(
                        dest => dest.IsKhuyenMai,
                        opt => opt.MapFrom(src => src.TrangThaiSale == 2 ? true : false)
                    )
                    .ForMember(
                        dest => dest.CongSac,
                        opt => opt.MapFrom(src => src.CongSac.LoaiCongSac)
                    )
                .ForMember(
                        dest => dest.ManHinh,
                        opt => opt.MapFrom(src => $"{src.ManHinh.LoaiManHinh} {src.ManHinh.KichThuoc} {src.ManHinh.TanSoQuet} ")
                    )
                 .ForMember(
                        dest => dest.TheNho,
                        opt => opt.MapFrom(src => $"{src.TheNho.LoaiTheNho} {src.TheNho.DungLuong}")
                    )
                .ForMember(
                        dest => dest.Chip,
                        opt => opt.MapFrom(src => src.Chip.TenChip)
                    )
              .ForMember(
                        dest => dest.Pin,
                        opt => opt.MapFrom(src => $"{src.Pin.LoaiPin} {src.Pin.DungLuong}")

                    )
                ;
            CreateMap<SanPhamDTO, SanPham>();
            CreateMap<HangDTO, Hang>();
            CreateMap<RamDTO, Ram>();
            CreateMap<RomDTO, Rom>();
            CreateMap<TheSimDTO, TheSim>();
            CreateMap<CameraSauDTO, CameraSau>();
            CreateMap<CameraTruocDTO, CameraTruoc>();
            CreateMap<ManHinhDTO, ManHinh>();
            CreateMap<CongSacDTO, CongSac>();
            CreateMap<PinDTO, Pin>();
            CreateMap<ChipDTO, Chip>();
            CreateMap<TheNhoDTO, TheNho>();
            CreateMap<KhuyenMaiChiTiet, KhuyenMaiChiTietDTO>()
                .ForMember(
                        dest => dest.KhuyenMai,
                        opt => opt.MapFrom(src => src.KhuyenMai.TenKhuyenMai)
                )
                .ForMember(
                        dest => dest.SanPham,
                        opt => opt.MapFrom(src => src.SanPhamChiTiet.SanPham.TenSanPham)
                )
                .ReverseMap();
            //CreateMap<ChiTietCamera, ChiTietCameraDTO>()
            //    .ForMember(
            //            dest => dest.Camera,
            //            opt => opt.MapFrom(src => src.Camera.DoPhanGiai)
            //    )
            //    .ForMember(
            //            dest => dest.SanPhamChiTiet,
            //            opt => opt.MapFrom(src => src.SanPhamChiTiet.SanPham.TenSanPham)
            //    )
            //    .ReverseMap();
            CreateMap<SanPhamYeuThichDTO, SanPhamYeuThich>();
            CreateMap<SanPhamYeuThich, SanPhamYeuThichViewModel>()
                .ForMember(
                        dest => dest.GiaBan,
                        opt => opt.MapFrom(src => src.SanPhamChiTiet.GiaBan)
                )
                .ForMember(
                        dest => dest.IdSanPhamChiTiet,
                        opt => opt.MapFrom(src => src.SanPhamChiTiet.IdChiTietSp)
                )
                .ForMember(
                        dest => dest.GiaThucTe,
                        opt => opt.MapFrom(src => src.SanPhamChiTiet.GiaThucTe)
                )
                .ForMember(
                        dest => dest.TenSanPham,
                        opt => opt.MapFrom(src => $"{src.SanPhamChiTiet.SanPham.TenSanPham} {src.SanPhamChiTiet.Ram.DungLuong}/{src.SanPhamChiTiet.Rom.DungLuong}")
                )
                .ForMember(
                        dest => dest.Anh,
                        opt => opt.MapFrom(src => src.SanPhamChiTiet.Anh.OrderBy(x => x.NgayTao).FirstOrDefault()!.Url)
                );
        }
    }
}
