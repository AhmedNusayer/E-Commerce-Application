using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce.Migrations
{
    public partial class ModelEng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    c_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    c_title = table.Column<string>(nullable: true),
                    c_imgLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "categoryEngs",
                columns: table => new
                {
                    c_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    c_title_eng = table.Column<string>(nullable: true),
                    c_imgLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryEngs", x => x.c_id);
                });

            migrationBuilder.CreateTable(
                name: "productEngs",
                columns: table => new
                {
                    p_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    c_Id = table.Column<int>(nullable: false),
                    p_title = table.Column<string>(nullable: true),
                    amount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productEngs", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    p_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    c_Id = table.Column<int>(nullable: false),
                    p_title = table.Column<string>(nullable: true),
                    amount = table.Column<string>(nullable: true),
                    price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.p_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "categoryEngs");

            migrationBuilder.DropTable(
                name: "productEngs");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
