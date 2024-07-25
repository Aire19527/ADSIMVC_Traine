using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class addtableState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdState",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Ambit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_IdState",
                table: "Product",
                column: "IdState");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_State_IdState",
                table: "Product",
                column: "IdState",
                principalTable: "State",
                principalColumn: "IdState",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_State_IdState",
                table: "Product");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Product_IdState",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IdState",
                table: "Product");
        }
    }
}
