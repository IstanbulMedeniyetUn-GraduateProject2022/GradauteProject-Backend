using Microsoft.EntityFrameworkCore.Migrations;

namespace GraduateProject.Common.Migrations
{
    public partial class AddingClicksNumberColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClicksNumber",
                table: "PlaceToVisit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClicksNumber",
                table: "MedicalCenter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClicksNumber",
                table: "Hotel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClicksNumber",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClicksNumber",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClicksNumber",
                table: "PlaceToVisit");

            migrationBuilder.DropColumn(
                name: "ClicksNumber",
                table: "MedicalCenter");

            migrationBuilder.DropColumn(
                name: "ClicksNumber",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "ClicksNumber",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ClicksNumber",
                table: "Department");
        }
    }
}
