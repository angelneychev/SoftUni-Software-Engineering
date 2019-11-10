using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Migrations
{
    public partial class AddDoctors1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "specialty",
                table: "Doctors",
                newName: "Specialty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Doctors",
                newName: "specialty");
        }
    }
}
