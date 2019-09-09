using Microsoft.EntityFrameworkCore.Migrations;

namespace IAR.Infrastructure.Migrations
{
    public partial class Seed_Test_Department : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "IsIAO",
                table: "Users",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DPOName", "DataControllerName", "DepartmentAbbreviation", "DepartmentName" },
                values: new object[] { 1, "Jenny Lynn", "Department of Finance", "DoF", "Department of Finance" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.AlterColumn<short>(
                name: "IsIAO",
                table: "Users",
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
