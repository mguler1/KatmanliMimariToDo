using Microsoft.EntityFrameworkCore.Migrations;

namespace YSKProje.ToDo.DataAccess.Migrations
{
    public partial class _CreateTableUrun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<int>(
                name: "UrunId",
                table: "Gorevler",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Urunler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(nullable: true),
                    UrunAciklama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_UrunId",
                table: "Gorevler",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_Urunler_UrunId",
                table: "Gorevler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_Urunler_UrunId",
                table: "Gorevler");

            migrationBuilder.DropTable(
                name: "Urunler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_UrunId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "UrunId",
                table: "Gorevler");

         
        }
    }
}
