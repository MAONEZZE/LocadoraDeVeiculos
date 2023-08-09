using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addtbAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDeCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KMPercorrido = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CupomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NivelCombustivelAtual = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    EstaAberto = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ValorTotalPrevisto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBAutomovel_AutomovelId",
                        column: x => x.AutomovelId,
                        principalTable: "TBAutomovel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCondutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCupom_CupomId",
                        column: x => x.CupomId,
                        principalTable: "TBCupom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBFuncionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBGrupoAutomovel_GrupoAutomovelId",
                        column: x => x.GrupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBPlanoDeCobranca_PlanoDeCobrancaId",
                        column: x => x.PlanoDeCobrancaId,
                        principalTable: "TBPlanoDeCobranca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBAluguel_TBTaxaServico",
                columns: table => new
                {
                    AluguelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxasServicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel_TBTaxaServico", x => new { x.AluguelId, x.TaxasServicosId });
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxaServico_TBAluguel_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "TBAluguel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxaServico_TBTaxaServico_TaxasServicosId",
                        column: x => x.TaxasServicosId,
                        principalTable: "TBTaxaServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_AutomovelId",
                table: "TBAluguel",
                column: "AutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_ClienteId",
                table: "TBAluguel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CondutorId",
                table: "TBAluguel",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CupomId",
                table: "TBAluguel",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_FuncionarioId",
                table: "TBAluguel",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_GrupoAutomovelId",
                table: "TBAluguel",
                column: "GrupoAutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_PlanoDeCobrancaId",
                table: "TBAluguel",
                column: "PlanoDeCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TBTaxaServico_TaxasServicosId",
                table: "TBAluguel_TBTaxaServico",
                column: "TaxasServicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAluguel_TBTaxaServico");

            migrationBuilder.DropTable(
                name: "TBAluguel");
        }
    }
}
