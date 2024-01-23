using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Models.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcaAeronave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaAeronave", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MarcaHelice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Componente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoComponente", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ModeloAeronave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloAeronave", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModeloAeronave_MarcaAeronave_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "MarcaAeronave",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeloHelice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarcaID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Catalogo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoID = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiempoRemplazoHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TiempoRemplazoMeses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Catalogo_TipoComponente_TipoID",
                        column: x => x.TipoID,
                        principalTable: "TipoComponente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aeronave",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloID = table.Column<int>(type: "int", nullable: false),
                    MonoMotor = table.Column<bool>(type: "bit", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Propietario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronave", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aeronave_ModeloAeronave_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "ModeloAeronave",
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
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asignacion = table.Column<bool>(type: "bit", nullable: false),
                    TiempoTotalHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HrsTURM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                name: "Componente",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AeronaveID = table.Column<int>(type: "int", nullable: false),
                    CatalogoID = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asignacion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Componente_Aeronave_AeronaveID",
                        column: x => x.AeronaveID,
                        principalTable: "Aeronave",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componente_Catalogo_CatalogoID",
                        column: x => x.CatalogoID,
                        principalTable: "Catalogo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvionID = table.Column<int>(type: "int", nullable: true),
                    HeliceID = table.Column<int>(type: "int", nullable: false),
                    ModeloID = table.Column<int>(type: "int", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Asignacion = table.Column<bool>(type: "bit", nullable: false),
                    TiempoTotalHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HrsTURM = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motor_Aeronave_AvionID",
                        column: x => x.AvionID,
                        principalTable: "Aeronave",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Motor_Helice_HeliceID",
                        column: x => x.HeliceID,
                        principalTable: "Helice",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Motor_ModeloMotor_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "ModeloMotor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguimiento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotorID = table.Column<int>(type: "int", nullable: true),
                    HeliceID = table.Column<int>(type: "int", nullable: true),
                    ComponenteID = table.Column<int>(type: "int", nullable: true),
                    UltimaAplicacionHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UltimaAplicacionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProximaAplicacionHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProximaAplicacionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemanenteHrs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemanenteMeses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimiento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seguimiento_Componente_ComponenteID",
                        column: x => x.ComponenteID,
                        principalTable: "Componente",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Seguimiento_Helice_HeliceID",
                        column: x => x.HeliceID,
                        principalTable: "Helice",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Seguimiento_Motor_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeronave_ModeloID",
                table: "Aeronave",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogo_TipoID",
                table: "Catalogo",
                column: "TipoID");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_AeronaveID",
                table: "Componente",
                column: "AeronaveID");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_CatalogoID",
                table: "Componente",
                column: "CatalogoID");

            migrationBuilder.CreateIndex(
                name: "IX_Helice_ModeloID",
                table: "Helice",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloAeronave_MarcaID",
                table: "ModeloAeronave",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloHelice_MarcaID",
                table: "ModeloHelice",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloMotor_MarcaID",
                table: "ModeloMotor",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_AvionID",
                table: "Motor",
                column: "AvionID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_HeliceID",
                table: "Motor",
                column: "HeliceID");

            migrationBuilder.CreateIndex(
                name: "IX_Motor_ModeloID",
                table: "Motor",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_ComponenteID",
                table: "Seguimiento",
                column: "ComponenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_HeliceID",
                table: "Seguimiento",
                column: "HeliceID");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimiento_MotorID",
                table: "Seguimiento",
                column: "MotorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seguimiento");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Motor");

            migrationBuilder.DropTable(
                name: "Catalogo");

            migrationBuilder.DropTable(
                name: "Aeronave");

            migrationBuilder.DropTable(
                name: "Helice");

            migrationBuilder.DropTable(
                name: "ModeloMotor");

            migrationBuilder.DropTable(
                name: "TipoComponente");

            migrationBuilder.DropTable(
                name: "ModeloAeronave");

            migrationBuilder.DropTable(
                name: "ModeloHelice");

            migrationBuilder.DropTable(
                name: "MarcaMotor");

            migrationBuilder.DropTable(
                name: "MarcaAeronave");

            migrationBuilder.DropTable(
                name: "MarcaHelice");
        }
    }
}
