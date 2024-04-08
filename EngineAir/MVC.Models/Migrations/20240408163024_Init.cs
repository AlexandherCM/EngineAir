using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Models.Migrations
{
    public partial class Init : Migration
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
                name: "Perfil",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.ID);
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
                    MarcaTipoID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloHelice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeloHelice_MarcaHelice_MarcaTipoID",
                        column: x => x.MarcaTipoID,
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
                    MarcaTipoID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloMotor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeloMotor_MarcaMotor_MarcaTipoID",
                        column: x => x.MarcaTipoID,
                        principalTable: "MarcaMotor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerfilID = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilID",
                        column: x => x.PerfilID,
                        principalTable: "Perfil",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variante",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaTipoID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variante", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Variante_TipoComponente_MarcaTipoID",
                        column: x => x.MarcaTipoID,
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
                    AeronaveID = table.Column<int>(type: "int", nullable: true),
                    Funcional = table.Column<bool>(type: "bit", nullable: false),
                    NumSerie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TURM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "HistorialMotorHelice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AeronaveID = table.Column<int>(type: "int", nullable: true),
                    MotorID = table.Column<int>(type: "int", nullable: false),
                    HeliceID = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMotorHelice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HistorialMotorHelice_Helice_HeliceID",
                        column: x => x.HeliceID,
                        principalTable: "Helice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialMotorHelice_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
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
                name: "IX_HistorialMotorHelice_HeliceID",
                table: "HistorialMotorHelice",
                column: "HeliceID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialMotorHelice_MotorID",
                table: "HistorialMotorHelice",
                column: "MotorID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloHelice_MarcaTipoID",
                table: "ModeloHelice",
                column: "MarcaTipoID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloMotor_MarcaTipoID",
                table: "ModeloMotor",
                column: "MarcaTipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_ModeloID",
                table: "Motor",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilID",
                table: "Usuario",
                column: "PerfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Variante_MarcaTipoID",
                table: "Variante",
                column: "MarcaTipoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "HistorialMotorHelice");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Variante");

            migrationBuilder.DropTable(
                name: "Helice");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "TipoComponente");

            migrationBuilder.DropTable(
                name: "ModeloHelice");

            migrationBuilder.DropTable(
                name: "ModeloMotor");

            migrationBuilder.DropTable(
                name: "MarcaHelice");

            migrationBuilder.DropTable(
                name: "MarcaMotor");
        }
    }
}
