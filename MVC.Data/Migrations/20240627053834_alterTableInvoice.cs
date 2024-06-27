using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class alterTableInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdInvoiceType",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InvoiceType",
                columns: table => new
                {
                    IdInvoiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.IdInvoiceType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_IdInvoiceType",
                table: "Invoice",
                column: "IdInvoiceType");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_InvoiceType_IdInvoiceType",
                table: "Invoice",
                column: "IdInvoiceType",
                principalTable: "InvoiceType",
                principalColumn: "IdInvoiceType",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_InvoiceType_IdInvoiceType",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceType");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_IdInvoiceType",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "IdInvoiceType",
                table: "Invoice");
        }
    }
}
