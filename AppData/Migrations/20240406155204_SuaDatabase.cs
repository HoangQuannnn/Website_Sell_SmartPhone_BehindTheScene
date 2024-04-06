using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data.Migrations
{
    public partial class SuaDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_ChatLieu_IdChatLieu",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_KichCo_IdKichCo",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_KieuDeGiay_IdKieuDeGiay",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_LoaiGiay_IdLoaiGiay",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_ThuongHieu_IdThuongHieu",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_XuatXu_IdXuatXu",
                table: "SanPhamChiTiet");

            migrationBuilder.DropTable(
                name: "ChatLieu");

            migrationBuilder.DropTable(
                name: "KichCo");

            migrationBuilder.DropTable(
                name: "KieuDeGiay");

            migrationBuilder.DropTable(
                name: "LoaiGiay");

            migrationBuilder.DropTable(
                name: "ThuongHieu");

            migrationBuilder.DropTable(
                name: "XuatXu");

            migrationBuilder.RenameColumn(
                name: "IdXuatXu",
                table: "SanPhamChiTiet",
                newName: "IdTheNho");

            migrationBuilder.RenameColumn(
                name: "IdThuongHieu",
                table: "SanPhamChiTiet",
                newName: "IdRom");

            migrationBuilder.RenameColumn(
                name: "IdLoaiGiay",
                table: "SanPhamChiTiet",
                newName: "IdRam");

            migrationBuilder.RenameColumn(
                name: "IdKieuDeGiay",
                table: "SanPhamChiTiet",
                newName: "IdPin");

            migrationBuilder.RenameColumn(
                name: "IdKichCo",
                table: "SanPhamChiTiet",
                newName: "IdManHinh");

            migrationBuilder.RenameColumn(
                name: "IdChatLieu",
                table: "SanPhamChiTiet",
                newName: "IdHang");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdXuatXu",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdTheNho");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdThuongHieu",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdRom");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdLoaiGiay",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdRam");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdKieuDeGiay",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdPin");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdKichCo",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdManHinh");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdChatLieu",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdHang");

            migrationBuilder.AddColumn<string>(
                name: "IdChip",
                table: "SanPhamChiTiet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdCongSac",
                table: "SanPhamChiTiet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Camera",
                columns: table => new
                {
                    IdCamera = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCamera = table.Column<string>(type: "varchar(50)", nullable: true),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera", x => x.IdCamera);
                });

            migrationBuilder.CreateTable(
                name: "CameraSau",
                columns: table => new
                {
                    IdCameraSau = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCameraSau = table.Column<string>(type: "varchar(50)", nullable: true),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiCamera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    IdSanPhamChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraSau", x => x.IdCameraSau);
                    table.ForeignKey(
                        name: "FK_CameraSau_SanPhamChiTiet_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IdChiTietSp");
                });

            migrationBuilder.CreateTable(
                name: "CameraTruoc",
                columns: table => new
                {
                    IdCameraTruoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCameraTruoc = table.Column<string>(type: "varchar(50)", nullable: true),
                    DoPhanGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiCamera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    IdSanPhamChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraTruoc", x => x.IdCameraTruoc);
                    table.ForeignKey(
                        name: "FK_CameraTruoc_SanPhamChiTiet_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IdChiTietSp");
                });

            migrationBuilder.CreateTable(
                name: "Chip",
                columns: table => new
                {
                    IdChip = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaChip = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenChip = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chip", x => x.IdChip);
                });

            migrationBuilder.CreateTable(
                name: "CongSac",
                columns: table => new
                {
                    IdCongSac = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaCongSac = table.Column<string>(type: "varchar(50)", nullable: true),
                    LoaiCongSac = table.Column<string>(type: "varchar(100)", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongSac", x => x.IdCongSac);
                });

            migrationBuilder.CreateTable(
                name: "Hang",
                columns: table => new
                {
                    IdHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHang = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenHang = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hang", x => x.IdHang);
                });

            migrationBuilder.CreateTable(
                name: "Imei",
                columns: table => new
                {
                    IdImei = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdSanPhamChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoImei = table.Column<string>(type: "varchar(50)", nullable: true),
                    MaVach = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imei", x => x.IdImei);
                    table.ForeignKey(
                        name: "FK_Imei_SanPhamChiTiet_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IdChiTietSp");
                });

            migrationBuilder.CreateTable(
                name: "ImeiChuaBan",
                columns: table => new
                {
                    IdImeiChuaBan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdGioHangChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoImei = table.Column<string>(type: "varchar(50)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImeiChuaBan", x => x.IdImeiChuaBan);
                    table.ForeignKey(
                        name: "FK_ImeiChuaBan_GioHangChiTiet_IdGioHangChiTiet",
                        column: x => x.IdGioHangChiTiet,
                        principalTable: "GioHangChiTiet",
                        principalColumn: "IdGioHangChiTiet");
                });

            migrationBuilder.CreateTable(
                name: "ImeiDaBan",
                columns: table => new
                {
                    IdImeiDaBan = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdHoaDonChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SoImei = table.Column<string>(type: "varchar(50)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImeiDaBan", x => x.IdImeiDaBan);
                    table.ForeignKey(
                        name: "FK_ImeiDaBan_HoaDonChiTiet_IdHoaDonChiTiet",
                        column: x => x.IdHoaDonChiTiet,
                        principalTable: "HoaDonChiTiet",
                        principalColumn: "IdHoaDonChiTiet");
                });

            migrationBuilder.CreateTable(
                name: "ManHinh",
                columns: table => new
                {
                    IdManHinh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaManHinh = table.Column<string>(type: "varchar(50)", nullable: true),
                    KichThuoc = table.Column<int>(type: "int", nullable: true),
                    LoaiManHinh = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TanSoQuet = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManHinh", x => x.IdManHinh);
                });

            migrationBuilder.CreateTable(
                name: "Pin",
                columns: table => new
                {
                    IdPin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiPin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DungLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pin", x => x.IdPin);
                });

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    IdRam = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaRam = table.Column<string>(type: "varchar(50)", nullable: true),
                    DungLuong = table.Column<string>(type: "varchar(50)", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.IdRam);
                });

            migrationBuilder.CreateTable(
                name: "Rom",
                columns: table => new
                {
                    IdRom = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaRom = table.Column<string>(type: "varchar(50)", nullable: true),
                    DungLuong = table.Column<string>(type: "varchar(50)", nullable: true),
                    TrangThai = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rom", x => x.IdRom);
                });

            migrationBuilder.CreateTable(
                name: "TheNho",
                columns: table => new
                {
                    IdTheNho = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiTheNho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DungLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheNho", x => x.IdTheNho);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietCamera",
                columns: table => new
                {
                    IdChiTietCamera = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdCamera = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdSanPhamChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LoaiCamera = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietCamera", x => x.IdChiTietCamera);
                    table.ForeignKey(
                        name: "FK_ChiTietCamera_Camera_IdCamera",
                        column: x => x.IdCamera,
                        principalTable: "Camera",
                        principalColumn: "IdCamera");
                    table.ForeignKey(
                        name: "FK_ChiTietCamera_SanPhamChiTiet_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IdChiTietSp");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IdChip",
                table: "SanPhamChiTiet",
                column: "IdChip");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamChiTiet_IdCongSac",
                table: "SanPhamChiTiet",
                column: "IdCongSac");

            migrationBuilder.CreateIndex(
                name: "IX_CameraSau_IdSanPhamChiTiet",
                table: "CameraSau",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_CameraTruoc_IdSanPhamChiTiet",
                table: "CameraTruoc",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCamera_IdCamera",
                table: "ChiTietCamera",
                column: "IdCamera");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietCamera_IdSanPhamChiTiet",
                table: "ChiTietCamera",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_Imei_IdSanPhamChiTiet",
                table: "Imei",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_ImeiChuaBan_IdGioHangChiTiet",
                table: "ImeiChuaBan",
                column: "IdGioHangChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_ImeiDaBan_IdHoaDonChiTiet",
                table: "ImeiDaBan",
                column: "IdHoaDonChiTiet");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_Chip_IdChip",
                table: "SanPhamChiTiet",
                column: "IdChip",
                principalTable: "Chip",
                principalColumn: "IdChip",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_CongSac_IdCongSac",
                table: "SanPhamChiTiet",
                column: "IdCongSac",
                principalTable: "CongSac",
                principalColumn: "IdCongSac",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_Hang_IdHang",
                table: "SanPhamChiTiet",
                column: "IdHang",
                principalTable: "Hang",
                principalColumn: "IdHang",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_ManHinh_IdManHinh",
                table: "SanPhamChiTiet",
                column: "IdManHinh",
                principalTable: "ManHinh",
                principalColumn: "IdManHinh",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_Pin_IdPin",
                table: "SanPhamChiTiet",
                column: "IdPin",
                principalTable: "Pin",
                principalColumn: "IdPin",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_Ram_IdRam",
                table: "SanPhamChiTiet",
                column: "IdRam",
                principalTable: "Ram",
                principalColumn: "IdRam",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_Rom_IdRom",
                table: "SanPhamChiTiet",
                column: "IdRom",
                principalTable: "Rom",
                principalColumn: "IdRom",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_TheNho_IdTheNho",
                table: "SanPhamChiTiet",
                column: "IdTheNho",
                principalTable: "TheNho",
                principalColumn: "IdTheNho",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_Chip_IdChip",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_CongSac_IdCongSac",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_Hang_IdHang",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_ManHinh_IdManHinh",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_Pin_IdPin",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_Ram_IdRam",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_Rom_IdRom",
                table: "SanPhamChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamChiTiet_TheNho_IdTheNho",
                table: "SanPhamChiTiet");

            migrationBuilder.DropTable(
                name: "CameraSau");

            migrationBuilder.DropTable(
                name: "CameraTruoc");

            migrationBuilder.DropTable(
                name: "Chip");

            migrationBuilder.DropTable(
                name: "ChiTietCamera");

            migrationBuilder.DropTable(
                name: "CongSac");

            migrationBuilder.DropTable(
                name: "Hang");

            migrationBuilder.DropTable(
                name: "Imei");

            migrationBuilder.DropTable(
                name: "ImeiChuaBan");

            migrationBuilder.DropTable(
                name: "ImeiDaBan");

            migrationBuilder.DropTable(
                name: "ManHinh");

            migrationBuilder.DropTable(
                name: "Pin");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "Rom");

            migrationBuilder.DropTable(
                name: "TheNho");

            migrationBuilder.DropTable(
                name: "Camera");

            migrationBuilder.DropIndex(
                name: "IX_SanPhamChiTiet_IdChip",
                table: "SanPhamChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_SanPhamChiTiet_IdCongSac",
                table: "SanPhamChiTiet");

            migrationBuilder.DropColumn(
                name: "IdChip",
                table: "SanPhamChiTiet");

            migrationBuilder.DropColumn(
                name: "IdCongSac",
                table: "SanPhamChiTiet");

            migrationBuilder.RenameColumn(
                name: "IdTheNho",
                table: "SanPhamChiTiet",
                newName: "IdXuatXu");

            migrationBuilder.RenameColumn(
                name: "IdRom",
                table: "SanPhamChiTiet",
                newName: "IdThuongHieu");

            migrationBuilder.RenameColumn(
                name: "IdRam",
                table: "SanPhamChiTiet",
                newName: "IdLoaiGiay");

            migrationBuilder.RenameColumn(
                name: "IdPin",
                table: "SanPhamChiTiet",
                newName: "IdKieuDeGiay");

            migrationBuilder.RenameColumn(
                name: "IdManHinh",
                table: "SanPhamChiTiet",
                newName: "IdKichCo");

            migrationBuilder.RenameColumn(
                name: "IdHang",
                table: "SanPhamChiTiet",
                newName: "IdChatLieu");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdTheNho",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdXuatXu");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdRom",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdThuongHieu");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdRam",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdLoaiGiay");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdPin",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdKieuDeGiay");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdManHinh",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdKichCo");

            migrationBuilder.RenameIndex(
                name: "IX_SanPhamChiTiet_IdHang",
                table: "SanPhamChiTiet",
                newName: "IX_SanPhamChiTiet_IdChatLieu");

            migrationBuilder.CreateTable(
                name: "ChatLieu",
                columns: table => new
                {
                    IdChatLieu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaChatLieu = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenChatLieu = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLieu", x => x.IdChatLieu);
                });

            migrationBuilder.CreateTable(
                name: "KichCo",
                columns: table => new
                {
                    IdKichCo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKichCo = table.Column<string>(type: "varchar(50)", nullable: true),
                    SoKichCo = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichCo", x => x.IdKichCo);
                });

            migrationBuilder.CreateTable(
                name: "KieuDeGiay",
                columns: table => new
                {
                    IdKieuDeGiay = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKieuDeGiay = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenKieuDeGiay = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Trangthai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KieuDeGiay", x => x.IdKieuDeGiay);
                });

            migrationBuilder.CreateTable(
                name: "LoaiGiay",
                columns: table => new
                {
                    IdLoaiGiay = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaLoaiGiay = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenLoaiGiay = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiGiay", x => x.IdLoaiGiay);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    IdThuongHieu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaThuongHieu = table.Column<string>(type: "varchar(50)", nullable: true),
                    TenThuongHieu = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieu", x => x.IdThuongHieu);
                });

            migrationBuilder.CreateTable(
                name: "XuatXu",
                columns: table => new
                {
                    IdXuatXu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ma = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XuatXu", x => x.IdXuatXu);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_ChatLieu_IdChatLieu",
                table: "SanPhamChiTiet",
                column: "IdChatLieu",
                principalTable: "ChatLieu",
                principalColumn: "IdChatLieu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_KichCo_IdKichCo",
                table: "SanPhamChiTiet",
                column: "IdKichCo",
                principalTable: "KichCo",
                principalColumn: "IdKichCo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_KieuDeGiay_IdKieuDeGiay",
                table: "SanPhamChiTiet",
                column: "IdKieuDeGiay",
                principalTable: "KieuDeGiay",
                principalColumn: "IdKieuDeGiay",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_LoaiGiay_IdLoaiGiay",
                table: "SanPhamChiTiet",
                column: "IdLoaiGiay",
                principalTable: "LoaiGiay",
                principalColumn: "IdLoaiGiay",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_ThuongHieu_IdThuongHieu",
                table: "SanPhamChiTiet",
                column: "IdThuongHieu",
                principalTable: "ThuongHieu",
                principalColumn: "IdThuongHieu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamChiTiet_XuatXu_IdXuatXu",
                table: "SanPhamChiTiet",
                column: "IdXuatXu",
                principalTable: "XuatXu",
                principalColumn: "IdXuatXu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
