using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    public partial class Adding_Cart_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "tblCart");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "tblCart");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "tblCart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "tblCart");

            migrationBuilder.CreateTable(
                name: "tblCartDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    ItemName = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    Quantity = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCartDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblCart_tblCartId",
                        column: x => x.ItemId,
                        principalTable: "tblCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetail_ItemId",
                table: "tblCartDetail",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCartDetail");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "tblCart",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "tblCart",
                nullable: false,
                defaultValueSql: "('')");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "tblCart",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "tblCart",
                nullable: false,
                defaultValueSql: "((0))");
        }
    }
}
