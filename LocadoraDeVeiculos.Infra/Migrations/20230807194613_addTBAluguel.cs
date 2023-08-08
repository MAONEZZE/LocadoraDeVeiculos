using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraDeVeiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addTBAluguel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPreco",
                table: "TBPlanoDeCobranca");

            migrationBuilder.DropColumn(
                name: "KmAutomovelAtual",
                table: "TBAluguel");

            migrationBuilder.RenameColumn(
                name: "ValorParcial",
                table: "TBAluguel",
                newName: "KMPercorrido");

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "TBAluguel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotalPrevisto",
                table: "TBAluguel",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotalPrevisto",
                table: "TBAluguel");

            migrationBuilder.RenameColumn(
                name: "KMPercorrido",
                table: "TBAluguel",
                newName: "ValorParcial");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPreco",
                table: "TBPlanoDeCobranca",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "ValorTotal",
                table: "TBAluguel",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldDefaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "KmAutomovelAtual",
                table: "TBAluguel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
