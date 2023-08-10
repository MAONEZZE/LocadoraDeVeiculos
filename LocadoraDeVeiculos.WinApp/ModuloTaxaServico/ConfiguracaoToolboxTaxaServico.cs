namespace LocadoraDeVeiculos.WinApp.ModuloTaxaServico
{
    public class ConfiguracaoToolboxTaxaServico : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Taxa ou Serviço";

        public override string TooltipInserir => "Cadastrar " + TipoCadastro;

        public override string TooltipEditar => "Editar " + TipoCadastro;

        public override string TooltipExcluir => "Excluir " + TipoCadastro;
    }
}
