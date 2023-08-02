using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayerWebUI.Migrations
{
    public partial class InitialCatalogB2B : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FaturaUsts",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariKod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FATIRS_NO = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Tarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    TIPI = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    KDV_DAHILMI = table.Column<bool>(type: "bit", nullable: false),
                    SIPARIS_TEST = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PLA_KODU = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Proje_Kodu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaUsts", x => x.FaturaId);
                });

            migrationBuilder.CreateTable(
                name: "FatKalems",
                columns: table => new
                {
                    FaturaKalemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StokKodu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    STra_GCMIK = table.Column<double>(type: "float", maxLength: 15, nullable: false),
                    STra_NF = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    STra_BF = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    ProjeKodu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DEPO_KODU = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FatKalems", x => x.FaturaKalemId);
                    table.ForeignKey(
                        name: "FK_FatKalems_FaturaUsts_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "FaturaUsts",
                        principalColumn: "FaturaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FatKalems_FaturaId",
                table: "FatKalems",
                column: "FaturaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FatKalems");

            migrationBuilder.DropTable(
                name: "FaturaUsts");
        }
    }
}
