using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mitigation.Migrations
{
    /// <inheritdoc />
    public partial class CreateVSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreItemId",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StoreItemId",
                table: "Sales",
                column: "StoreItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Candidates_StoreItemId",
                table: "Sales",
                column: "StoreItemId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(@"
                CREATE VIEW PointOfSales.VSales AS
                SELECT 
                    s.Id AS SalesId,
                    s.SalesNumber,
                    s.StoreItemId,
                    si.Name
                FROM Sales s
                LEFT JOIN Candidates si ON s.StoreItemId = si.Id;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Candidates_StoreItemId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_StoreItemId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "StoreItemId",
                table: "Sales");
            migrationBuilder.Sql("DROP VIEW IF EXISTS PointOfSales.VSales;");
        }
    }
}
