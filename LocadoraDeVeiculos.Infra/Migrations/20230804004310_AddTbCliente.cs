using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTbCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo_de_Cliente = table.Column<string>(type: "varchar(30)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(250)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false),
                    CEP = table.Column<string>(type: "varchar(30)", nullable: false),
                    Número = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(30)", nullable: false),
                    Documento_do_Cliente = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_TBCupom_ListaCuponsId",
                table: "TBCliente_TBCupom",
                column: "ListaCuponsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCliente_TBCupom");

            migrationBuilder.DropTable(
                name: "TBCliente");
        }
    }
}
