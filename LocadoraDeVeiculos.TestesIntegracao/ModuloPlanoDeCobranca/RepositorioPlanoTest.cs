using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloPlanoDeCobranca
{
    [TestClass]
    public class RepositorioPlanoTest
    {
        private GrupoAutomovel gp;
        public RepositorioPlanoTest()
        {
            gp = Builder<GrupoAutomovel>.CreateNew().Persist();
        }

        [TestMethod]
        public void DeveInserir_Plano()
        {
            //Arrange
            var plano = Builder<PlanoDeCobranca>.CreateNew().With(p => p.GrupoAutomovel = gp).Build();


        }
    }
}
