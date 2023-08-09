﻿using FizzWare.NBuilder;
using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.TestesIntegracao.ModuloCupom
{
    [TestClass]

    public class RepositorioCupomTest : RepositorioBaseTests
    {
        Parceiro parceiro;

        public RepositorioCupomTest() : base()
        {
            parceiro = Builder<Parceiro>.CreateNew().Persist();
        }


        [TestMethod]
        public void Deve_inserir_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().With(x=>x.Parceiro = parceiro).Build();

            repositorioCupom.Inserir(cupom);

            dbContext.SaveChanges();

            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_editar_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();

            cupom = repositorioCupom.SelecionarPorId(cupom.Id);

            cupom.Valor = 100;

            repositorioCupom.Editar(cupom);

            dbContext.SaveChanges();

            repositorioCupom.SelecionarPorId(cupom.Id).Should().Be(cupom);
        }

        [TestMethod]
        public void Deve_excluir_cupom()
        {
            var cupom = Builder<Cupom>.CreateNew().With(x => x.Parceiro = parceiro).Persist();

            cupom = repositorioCupom.SelecionarPorId(cupom.Id);

            repositorioCupom.Excluir(cupom);

            dbContext.SaveChanges();

            repositorioCupom.SelecionarPorId(cupom.Id).Should().BeNull();
        }
    }
}
