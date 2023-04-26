using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMeterAPP.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CONDOMINIO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONDOMINIO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BLOCO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CondominioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLOCO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BLOCO_CONDOMINIO_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "CONDOMINIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UNIDADE",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlocoId = table.Column<int>(type: "int", nullable: true),
                    CondominioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIDADE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UNIDADE_BLOCO_BlocoId",
                        column: x => x.BlocoId,
                        principalTable: "BLOCO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UNIDADE_CONDOMINIO_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "CONDOMINIO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MEDICAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefixo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicaoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataHoraMedicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDICAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MEDICAO_UNIDADE_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "UNIDADE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLOCO_CondominioId",
                table: "BLOCO",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_MEDICAO_UnidadeId",
                table: "MEDICAO",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_UNIDADE_BlocoId",
                table: "UNIDADE",
                column: "BlocoId");

            migrationBuilder.CreateIndex(
                name: "IX_UNIDADE_CondominioId",
                table: "UNIDADE",
                column: "CondominioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEDICAO");

            migrationBuilder.DropTable(
                name: "UNIDADE");

            migrationBuilder.DropTable(
                name: "BLOCO");

            migrationBuilder.DropTable(
                name: "CONDOMINIO");
        }
    }
}
