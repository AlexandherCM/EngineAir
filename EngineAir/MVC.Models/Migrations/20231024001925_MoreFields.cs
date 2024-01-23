using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Models.Migrations
{
    public partial class MoreFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TiempoRemplazoHrs",
                table: "ModeloMotor",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TiempoRemplazoMeses",
                table: "ModeloMotor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TiempoRemplazoHrs",
                table: "ModeloHelice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TiempoRemplazoMeses",
                table: "ModeloHelice",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TiempoRemplazoHrs",
                table: "ModeloMotor");

            migrationBuilder.DropColumn(
                name: "TiempoRemplazoMeses",
                table: "ModeloMotor");

            migrationBuilder.DropColumn(
                name: "TiempoRemplazoHrs",
                table: "ModeloHelice");

            migrationBuilder.DropColumn(
                name: "TiempoRemplazoMeses",
                table: "ModeloHelice");
        }
    }
}
