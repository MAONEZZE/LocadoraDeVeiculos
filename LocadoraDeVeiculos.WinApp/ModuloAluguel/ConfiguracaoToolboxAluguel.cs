namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public class ConfiguracaoToolboxAluguel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Aluguel";

        public override string TooltipInserir => "Cadastrar " + TipoCadastro;

        public override string TooltipEditar => "Editar " + TipoCadastro;

        public override string TooltipExcluir => "Excluir " + TipoCadastro;

        public override string TooltipPrecoCombustivel => "Preço Combustivel";

        public override bool PrecoCombustivelHabilitado => true;

        public override string TooltipDevolverAutomovel => "Devolver Automovel";

        public override bool DevolverAutomovelHabilitado => true;
    }
}