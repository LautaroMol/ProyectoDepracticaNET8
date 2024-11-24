using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDePractica.BD.Migrations
{
    /// <inheritdoc />
    public partial class relac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumDoc",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TDocumentoId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NumDoc",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TDocumentoId",
                table: "Personas");
        }
    }
}
