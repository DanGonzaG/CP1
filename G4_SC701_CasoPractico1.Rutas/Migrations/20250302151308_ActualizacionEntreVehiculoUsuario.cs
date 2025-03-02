using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G4_SC701_CasoPractico1.Rutas.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionEntreVehiculoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Vehiculo",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_idUsuario",
                table: "Vehiculos");

            migrationBuilder.AddColumn<int>(
                name: "idVehiculo",
                table: "Vehiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_idUsuario",
                table: "Vehiculos",
                column: "idUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehiculo_usuario",
                table: "Vehiculos",
                column: "idUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehiculo_usuario",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_idUsuario",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "idVehiculo",
                table: "Vehiculos");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_idUsuario",
                table: "Vehiculos",
                column: "idUsuario",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Vehiculo",
                table: "Vehiculos",
                column: "idUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
