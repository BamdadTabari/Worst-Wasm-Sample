using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KernelLogic.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "BlogPostDmo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostAuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImageAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostDmo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageDmo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDmo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDmo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CountInStore = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageAlt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDmo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostDmo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ImageDmo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductDmo",
                schema: "dbo");
        }
    }
}
