namespace LocadoraDeVeiculos.WinApp.ModuloAluguel
{
    public class ConfiguracaoToolboxAluguel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Aluguel";

        public override string TooltipInserir => "Cadastrar " + TipoCadastro;

        public override string TooltipEditar => "Editar " + TipoCadastro;

        public override string TooltipExcluir => "Excluir " + TipoCadastro;
    }
}