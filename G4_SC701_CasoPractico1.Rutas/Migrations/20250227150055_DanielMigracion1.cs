using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G4_SC701_CasoPractico1.Rutas.Migrations
{
    /// <inheritdoc />
    public partial class DanielMigracion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idVehiculo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CapacidadPasajeros = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idVehiculo",
                table: "Usuarios",
                column: "idVehiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Vehiculos_idVehiculo",
                table: "Usuarios",
                column: "idVehiculo",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Vehiculos_idVehiculo",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_idVehiculo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "idVehiculo",
                table: "Usuarios");
        }
    }
}
