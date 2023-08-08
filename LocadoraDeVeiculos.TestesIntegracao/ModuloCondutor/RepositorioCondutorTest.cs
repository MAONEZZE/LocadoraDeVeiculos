using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.TestesIntegracao.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorTest : RepositorioBaseTests
    {
        private Cliente cliente;

        public RepositorioCondutorTest() : base()
        {
            cliente = Builder<Cliente>.CreateNew().Persist();
        }

        [TestMethod]
        public void DeveInserir_Condutor()
        {
            var condutor = Builder<Condutor>.CreateNew().Build();

            condutor.Cliente = cliente;

            repositorioCondutor.Inserir(condutor);

            var condutorEncontrado = repositorioCondutor.SelecionarPorId(condutor.Id);

            condutorEncontrado.Should().Be(condutor);
        }   
    }
}
