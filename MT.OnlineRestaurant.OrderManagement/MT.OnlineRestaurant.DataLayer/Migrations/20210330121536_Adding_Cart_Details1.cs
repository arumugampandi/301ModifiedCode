using Microsoft.EntityFrameworkCore.Migrations;

namespace MT.OnlineRestaurant.DataLayer.Migrations
{
    public partial class Adding_Cart_Details1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCart_tblCartId",
                table: "tblCartDetail");

            migrationBuilder.DropIndex(
                name: "IX_tblCartDetail_ItemId",
                table: "tblCartDetail");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "tblCartDetail",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetail_CartId",
                table: "tblCartDetail",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCart_tblCartId",
                table: "tblCartDetail",
                column: "CartId",
                principalTable: "tblCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblCart_tblCartId",
                table: "tblCartDetail");

            migrationBuilder.DropIndex(
                name: "IX_tblCartDetail_CartId",
                table: "tblCartDetail");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "tblCartDetail");

            migrationBuilder.CreateIndex(
                name: "IX_tblCartDetail_ItemId",
                table: "tblCartDetail",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_TblCart_tblCartId",
                table: "tblCartDetail",
                column: "ItemId",
                principalTable: "tblCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
