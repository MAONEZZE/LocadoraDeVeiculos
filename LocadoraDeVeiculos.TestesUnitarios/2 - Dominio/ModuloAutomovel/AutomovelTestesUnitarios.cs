using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.TestesUnitarios._2___Dominio.ModuloAutomovel
{

    [TestClass]
    public class AutomovelTestesUnitarios
    {
        Automovel automovel;
        public AutomovelTestesUnitarios()
        {
             automovel = new Automovel();
        }


        [TestMethod]
        public void Deve_calcular_total_de_litros_abastecidos()
        {
            automovel.CapacidadeDeCombustivel = 55;

            NivelCombustivelEnum nivel = NivelCombustivelEnum.Um_Quarto;

            double litrosAbastecidos = automovel.ObterLitrosAbastecidos(nivel);

            litrosAbastecidos.Should().Be(41.25);

        }

        [TestMethod]
        public void Deve_retornar_zero_se_tanque_estiver_cheio()
        {
            automovel.CapacidadeDeCombustivel = 55;

            NivelCombustivelEnum nivel = NivelCombustivelEnum.Cheio;

            double litrosAbastecidos = automovel.ObterLitrosAbastecidos(nivel);

            litrosAbastecidos.Should().Be(0);
        }

        [TestMethod]
        public void Deve_retornar_valor_igual_capacidade_do_tanque_se_tanque_estiver_vazio()
        {
            automovel.CapacidadeDeCombustivel = 55;

            NivelCombustivelEnum nivel = NivelCombustivelEnum.Vazio;

            double litrosAbastecidos = automovel.ObterLitrosAbastecidos(nivel);

            litrosAbastecidos.Should().Be(automovel.CapacidadeDeCombustivel);
        }


        [TestMethod]
        public void Deve_atualizar_quilometragem()
        {         
            automovel.Quilometragem = 15000;

            var kmPercorrido = 1800;

            automovel.AtualizarQuilometragem(kmPercorrido);

            automovel.Quilometragem.Should().Be(16800);
        }

        [TestMethod]
        public void Deve_criar_automovel_com_status_disponivel()
        {
            automovel.Alugado.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_tornar_automovel_indisponivel()
        {
            automovel.AlterarStatus();

            automovel.Alugado.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_tornar_automovel_disponivel()
        {
            automovel.Alugado = true;

            automovel.AlterarStatus();

            automovel.Alugado.Should().BeFalse();
        }

    }
}
