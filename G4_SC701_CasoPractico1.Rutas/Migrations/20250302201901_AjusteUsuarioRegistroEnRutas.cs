using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G4_SC701_CasoPractico1.Rutas.Migrations
{
    /// <inheritdoc />
    public partial class AjusteUsuarioRegistroEnRutas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Vehiculo",
                table: "Vehiculos");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistro",
                table: "Rutas");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioRegistroId",
                table: "Rutas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rutas_UsuarioRegistroId",
                table: "Rutas",
                column: "UsuarioRegistroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ruta_UsuarioRegistro",
                table: "Rutas",
                column: "UsuarioRegistroId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Vehiculo",
                table: "Vehiculos",
                column: "idUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ruta_UsuarioRegistro",
                table: "Rutas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Vehiculo",
                table: "Vehiculos");

            migrationBuilder.DropIndex(
                name: "IX_Rutas_UsuarioRegistroId",
                table: "Rutas");

            migrationBuilder.DropColumn(
                name: "UsuarioRegistroId",
                table: "Rutas");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioRegistro",
                table: "Rutas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
