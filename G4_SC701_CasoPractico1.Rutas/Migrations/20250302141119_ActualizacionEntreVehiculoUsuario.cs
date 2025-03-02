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
                name: "FK_Usuarios_Vehiculos_idVehiculo",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_idVehiculo",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "idVehiculo",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_idUsuario",
                table: "Vehiculos");

            migrationBuilder.AlterColumn<int>(
                name: "idVehiculo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
