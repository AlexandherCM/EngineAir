using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Models.Migrations
{
    public partial class DataDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insertar datos en la tabla Perfil
            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "ID", "Nombre" },
                values: new object[] { "ADM", "Administrador" });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "ID", "Nombre" },
                values: new object[] { "GRL", "Gestor de servicios" });

            // Insertar datos en la tabla Usuario
            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "PerfilID", "Nombre", "Correo", "Clave" },
                values: new object[] { "ADM", "Alexandher Cordoba", "alexandhercordoba378@gmail.com", "123456" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "PerfilID", "Nombre", "Correo", "Clave" },
                values: new object[] { "GRL", "Carlos Ivan", "carlosivanlopez@gmail.com", "654321" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
