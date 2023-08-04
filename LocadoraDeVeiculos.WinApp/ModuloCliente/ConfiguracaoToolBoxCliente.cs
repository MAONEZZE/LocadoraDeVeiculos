namespace LocadoraDeVeiculos.WinApp.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cliente";

        public override string TooltipInserir => "Inserir Cliente";

        public override string TooltipEditar => "Editar Cliente";

        public override string TooltipExcluir => "Excluir Cliente";

        public override string TooltipFiltrar => "Filtrar Cliente";

        public override bool FiltrarHabilitado => true; //Filtrar por cpf e cnpj
    }
}
