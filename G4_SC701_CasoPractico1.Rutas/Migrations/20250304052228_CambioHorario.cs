using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace G4_SC701_CasoPractico1.Rutas.Migrations
{
    /// <inheritdoc />
    public partial class CambioHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "Horario",
                table: "Horarios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Horario",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }
    }
}
