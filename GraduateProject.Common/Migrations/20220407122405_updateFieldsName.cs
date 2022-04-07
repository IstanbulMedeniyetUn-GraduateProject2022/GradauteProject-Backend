using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduateProject.Common.Migrations
{
    public partial class updateFieldsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MedicalCenterName",
                table: "MedicalCenterLog",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MedicalCenterLocation",
                table: "MedicalCenterLog",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "MedicalCenterDescription",
                table: "MedicalCenterLog",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "MedicalCenterAddress",
                table: "MedicalCenterLog",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "LanguageCode",
                table: "Language",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "DoctorLocation",
                table: "DoctorLog",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "DoctorAddress",
                table: "DoctorLog",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MedicalCenterLog",
                newName: "MedicalCenterName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "MedicalCenterLog",
                newName: "MedicalCenterLocation");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "MedicalCenterLog",
                newName: "MedicalCenterDescription");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "MedicalCenterLog",
                newName: "MedicalCenterAddress");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Language",
                newName: "LanguageCode");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "DoctorLog",
                newName: "DoctorLocation");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "DoctorLog",
                newName: "DoctorAddress");
        }
    }
}
