using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G4_SC701_CasoPractico1.Rutas.Migrations
{
    /// <inheritdoc />
    public partial class modificacionENRuta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parada_Rutas_rutaId",
                table: "Parada");

            migrationBuilder.DropColumn(
                name: "IdRuta",
                table: "Parada");

            migrationBuilder.RenameColumn(
                name: "rutaId",
                table: "Parada",
                newName: "RutaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parada_rutaId",
                table: "Parada",
                newName: "IX_Parada_RutaId");

            migrationBuilder.AlterColumn<int>(
                name: "RutaId",
                table: "Parada",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parada_Rutas_RutaId",
                table: "Parada",
                column: "RutaId",
                principalTable: "Rutas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parada_Rutas_RutaId",
                table: "Parada");

            migrationBuilder.RenameColumn(
                name: "RutaId",
                table: "Parada",
                newName: "rutaId");

            migrationBuilder.RenameIndex(
                name: "IX_Parada_RutaId",
                table: "Parada",
                newName: "IX_Parada_rutaId");

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "Parada",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdRuta",
                table: "Parada",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Parada_Rutas_rutaId",
                table: "Parada",
                column: "rutaId",
                principalTable: "Rutas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
