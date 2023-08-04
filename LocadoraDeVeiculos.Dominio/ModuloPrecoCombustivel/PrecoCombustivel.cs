using FluentResults;

namespace LocadoraDeVeiculos.Dominio.ModuloPrecoCombustivel
{

    [Serializable]

    public class PrecoCombustivel
    {
        public decimal Gasolina { get; set; }

        public decimal Etanol { get; set; }

        public decimal Diesel { get; set; }

        public decimal Gas { get; set; }

        public PrecoCombustivel()
        {

        }

        public Result Validar()
        {
            var erros = new List<string>();

            string combustivel;

            if (Gasolina <= 0)
                combustivel = "Gasolina";
            else if (Etanol <= 0)
                combustivel = "Etanol";
            else if (Diesel <= 0)
                combustivel = "Diesel";
            else if (Gas <= 0)
                combustivel = "Gás";
            else
                return Result.Ok();

            erros.Add($"O preço do {combustivel} não pode ser igual ou menor que zero");

            return Result.Fail(erros);

        }
    }


}
