using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addAtualizacaoTBCliente_e_TBPlanoCobranca_e_TBCondutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo de Cliente",
                table: "TBCliente",
                newName: "Tipo_de_Cliente");

            migrationBuilder.RenameColumn(
                name: "Documento do Cliente",
                table: "TBCliente",
                newName: "Documento_do_Cliente");

            migrationBuilder.CreateTable(
                name: "TBCliente_TBCupom",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListaCuponsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente_TBCupom", x => new { x.ClienteId, x.ListaCuponsId });
                    table.ForeignKey(
                        name: "FK_TBCliente_TBCupom_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBCliente_TBCupom_TBCupom_ListaCuponsId",
                        column: x => x.ListaCuponsId,
                        principalTable: "TBCupom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Validade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CNH = table.Column<string>(type: "varchar(50)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF_do_Condutor = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoDeCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Km_Disponivel = table.Column<int>(type: "int", nullable: false),
                    Preco_do_Km = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco_da_Diaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo_de_Plano = table.Column<string>(type: "varchar(30)", nullable: false),
                    GrupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoDeCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoDeCobranca_TBGrupoAutomovel_GrupoAutomovelId",
                        column: x => x.GrupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_TBCupom_ListaCuponsId",
                table: "TBCliente_TBCupom",
                column: "ListaCuponsId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoDeCobranca_GrupoAutomovelId",
                table: "TBPlanoDeCobranca",
                column: "GrupoAutomovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCliente_TBCupom");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBPlanoDeCobranca");

            migrationBuilder.RenameColumn(
                name: "Tipo_de_Cliente",
                table: "TBCliente",
                newName: "Tipo de Cliente");

            migrationBuilder.RenameColumn(
                name: "Documento_do_Cliente",
                table: "TBCliente",
                newName: "Documento do Cliente");
        }
    }
}
