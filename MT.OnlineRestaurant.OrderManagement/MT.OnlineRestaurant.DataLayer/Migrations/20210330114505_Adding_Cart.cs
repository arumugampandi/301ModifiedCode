using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    public partial class Adding_Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    ItemName = table.Column<string>(nullable: false, defaultValueSql: "('')"),
                    Quantity = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RestaurantId = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    CustomerId = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCart", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCart");
        }
    }
}
