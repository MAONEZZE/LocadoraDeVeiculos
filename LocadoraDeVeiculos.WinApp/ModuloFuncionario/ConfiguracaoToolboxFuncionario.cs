namespace LocadoraDeVeiculos.WinApp.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Funcionário";

        public override string TooltipInserir => "Cadastrar " + TipoCadastro;

        public override string TooltipEditar => "Editar " + TipoCadastro;

        public override string TooltipExcluir => "Excluir " + TipoCadastro;
    }
}