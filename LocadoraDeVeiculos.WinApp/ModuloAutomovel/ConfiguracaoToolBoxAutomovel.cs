
namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    internal class ConfiguracaoToolBoxAutomovel : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Automóvel";

        public override string TooltipInserir => "Cadastrar Automóvel";

        public override string TooltipEditar => "Editar Automóvel";

        public override string TooltipExcluir => "Excluir Automóvel";

        public override string TooltipVisualizar => "Visualizar Automóvel";

        public override bool VisualizarHabilitado => true;
    }
}
