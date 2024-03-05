using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Models.Migrations
{
    public partial class ChangeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaHelice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaHelice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MarcaMotor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaMotor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoComponente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComponente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModeloHelice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloHelice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeloHelice_MarcaHelice_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "MarcaHelice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloMotor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloMotor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeloMotor_MarcaMotor_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "MarcaMotor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Variante_TipoComponente_TipoID",
                        column: x => x.TipoID,
                        principalTable: "TipoComponente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Helice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloID = table.Column<int>(type: "int", nullable: false),
                    Funcional = table.Column<bool>(type: "bit", nullable: false),
                    NumSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TURM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Helice_ModeloHelice_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "ModeloHelice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloID = table.Column<int>(type: "int", nullable: false),
                    Aeronave = table.Column<int>(type: "int", nullable: true),
                    Funcional = table.Column<bool>(type: "bit", nullable: false),
                    NumSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TURM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motor_ModeloMotor_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "ModeloMotor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarianteID = table.Column<int>(type: "int", nullable: false),
                    Aeronave = table.Column<int>(type: "int", nullable: true),
                    Funcional = table.Column<bool>(type: "bit", nullable: false),
                    NumSerie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Componente_Variante_VarianteID",
                        column: x => x.VarianteID,
                        principalTable: "Variante",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componente_VarianteID",
                table: "Componente",
                column: "VarianteID");

            migrationBuilder.CreateIndex(
                name: "IX_Helice_ModeloID",
                table: "Helice",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloHelice_MarcaID",
                table: "ModeloHelice",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloMotor_MarcaID",
                table: "ModeloMotor",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_ModeloID",
                table: "Motor",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Variante_TipoID",
                table: "Variante",
                column: "TipoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Helice");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Variante");

            migrationBuilder.DropTable(
                name: "ModeloHelice");

            migrationBuilder.DropTable(
                name: "ModeloMotor");

            migrationBuilder.DropTable(
                name: "TipoComponente");

            migrationBuilder.DropTable(
                name: "MarcaHelice");

            migrationBuilder.DropTable(
                name: "MarcaMotor");
        }
    }
}
