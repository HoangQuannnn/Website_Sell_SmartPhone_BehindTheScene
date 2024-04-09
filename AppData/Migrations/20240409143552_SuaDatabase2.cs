using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App_Data.Migrations
{
    public partial class SuaDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaTheNho",
                table: "TheNho",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "Rom",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "Ram",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaPin",
                table: "Pin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "ManHinh",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TheSim",
                columns: table => new
                {
                    IdTheSim = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Loaithesim = table.Column<string>(type: "varchar(10)", nullable: true),
                    SoKhaySim = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheSim", x => x.IdTheSim);
                });

            migrationBuilder.CreateTable(
                name: "TheSimDienThoai",
                columns: table => new
                {
                    IdTheSimDienThoai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdTheSim = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdSanPhamChiTiet = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheSimDienThoai", x => x.IdTheSimDienThoai);
                    table.ForeignKey(
                        name: "FK_TheSimDienThoai_SanPhamChiTiet_IdSanPhamChiTiet",
                        column: x => x.IdSanPhamChiTiet,
                        principalTable: "SanPhamChiTiet",
                        principalColumn: "IdChiTietSp");
                    table.ForeignKey(
                        name: "FK_TheSimDienThoai_TheSim_IdTheSim",
                        column: x => x.IdTheSim,
                        principalTable: "TheSim",
                        principalColumn: "IdTheSim");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TheSimDienThoai_IdSanPhamChiTiet",
                table: "TheSimDienThoai",
                column: "IdSanPhamChiTiet");

            migrationBuilder.CreateIndex(
                name: "IX_TheSimDienThoai_IdTheSim",
                table: "TheSimDienThoai",
                column: "IdTheSim");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TheSimDienThoai");

            migrationBuilder.DropTable(
                name: "TheSim");

            migrationBuilder.DropColumn(
                name: "MaTheNho",
                table: "TheNho");

            migrationBuilder.DropColumn(
                name: "MaPin",
                table: "Pin");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ManHinh");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "Rom",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "Ram",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
