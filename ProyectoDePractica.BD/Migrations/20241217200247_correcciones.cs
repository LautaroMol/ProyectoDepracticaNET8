using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDePractica.BD.Migrations
{
    /// <inheritdoc />
    public partial class correcciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especialidades_TDocumentos_TDocumentoId",
                table: "Especialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_PersonaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesiones_TDocumentos_TDocumentoId",
                table: "Profesiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesiones_Titulos_TituloId",
                table: "Profesiones");

            migrationBuilder.DropIndex(
                name: "IX_Profesiones_TDocumentoId",
                table: "Profesiones");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PersonaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "TDocumentoId",
                table: "Profesiones");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "TDocumentoId",
                table: "Especialidades",
                newName: "TituloId");

            migrationBuilder.RenameIndex(
                name: "IX_Especialidades_TDocumentoId",
                table: "Especialidades",
                newName: "IX_Especialidades_TituloId");

            migrationBuilder.AlterColumn<int>(
                name: "TituloId",
                table: "Profesiones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidades_Titulos_TituloId",
                table: "Especialidades",
                column: "TituloId",
                principalTable: "Titulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesiones_Titulos_TituloId",
                table: "Profesiones",
                column: "TituloId",
                principalTable: "Titulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especialidades_Titulos_TituloId",
                table: "Especialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Profesiones_Titulos_TituloId",
                table: "Profesiones");

            migrationBuilder.RenameColumn(
                name: "TituloId",
                table: "Especialidades",
                newName: "TDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Especialidades_TituloId",
                table: "Especialidades",
                newName: "IX_Especialidades_TDocumentoId");

            migrationBuilder.AlterColumn<int>(
                name: "TituloId",
                table: "Profesiones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TDocumentoId",
                table: "Profesiones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesiones_TDocumentoId",
                table: "Profesiones",
                column: "TDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PersonaId",
                table: "Personas",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidades_TDocumentos_TDocumentoId",
                table: "Especialidades",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_PersonaId",
                table: "Personas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profesiones_TDocumentos_TDocumentoId",
                table: "Profesiones",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profesiones_Titulos_TituloId",
                table: "Profesiones",
                column: "TituloId",
                principalTable: "Titulos",
                principalColumn: "Id");
        }
    }
}
