using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateemployee3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "HR",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DepartmentId",
                schema: "HR",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "FileType",
                schema: "HR",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "HR",
                table: "Employee",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FileType",
                schema: "HR",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "HR",
                table: "Employee",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                schema: "HR",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentId",
                schema: "HR",
                table: "Employee",
                column: "DepartmentId",
                principalSchema: "HR",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
