using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
