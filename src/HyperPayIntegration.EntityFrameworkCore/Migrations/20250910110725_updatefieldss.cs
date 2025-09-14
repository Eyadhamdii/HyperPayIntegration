using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HyperPayIntegration.Migrations
{
    /// <inheritdoc />
    public partial class updatefieldss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BuildNumber",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntityId",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ndc",
                table: "PaymentTransactions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildNumber",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "PaymentTransactions");

            migrationBuilder.DropColumn(
                name: "Ndc",
                table: "PaymentTransactions");
        }
    }
}
