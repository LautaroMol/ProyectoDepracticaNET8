﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoDePractica.BD.Migrations
{
    /// <inheritdoc />
    public partial class entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "TDocumentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Personas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidadess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidadess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especialidadess_TDocumentos_TDocumentoId",
                        column: x => x.TDocumentoId,
                        principalTable: "TDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    TDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesiones_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesiones_TDocumentos_TDocumentoId",
                        column: x => x.TDocumentoId,
                        principalTable: "TDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfesionId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Especialidadess_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidadess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Profesiones_ProfesionId",
                        column: x => x.ProfesionId,
                        principalTable: "Profesiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PersonaId",
                table: "Personas",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "Especialidad_UQ",
                table: "Especialidadess",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especialidadess_TDocumentoId",
                table: "Especialidadess",
                column: "TDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_EspecialidadId",
                table: "Matriculas",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "Matricula_UQ",
                table: "Matriculas",
                columns: new[] { "ProfesionId", "EspecialidadId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profesiones_PersonaId",
                table: "Profesiones",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesiones_TDocumentoId",
                table: "Profesiones",
                column: "TDocumentoId");

            migrationBuilder.CreateIndex(
                name: "TDocumento_UQ",
                table: "TDocumentos",
                column: "Codigo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_PersonaId",
                table: "Personas",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_PersonaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Especialidadess");

            migrationBuilder.DropTable(
                name: "Profesiones");

            migrationBuilder.DropTable(
                name: "TDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PersonaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "TDocumentos");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Personas");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_TDocumentos_TDocumentoId",
                table: "Personas",
                column: "TDocumentoId",
                principalTable: "TDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
