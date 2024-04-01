using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Filename",
                schema: "HR",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filename",
                schema: "HR",
                table: "Employee");
        }
    }
}
