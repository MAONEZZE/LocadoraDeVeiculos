namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>, IValidadorAutomovel
    {
        public ValidadorAutomovel()
        {
            RuleFor(a => a.Id).NotNull();

            RuleFor(a => a.Marca).NotNull().MinimumLength(2);

            RuleFor(a => a.Ano.ToString()).Length(4).NotEmpty();

            RuleFor(a => a.CapacidadeDeCombustivel).GreaterThan(0);

            RuleFor(a => a.Placa).Custom(ValidarPlaca());

            RuleFor(a=>a.Modelo).NotNull().MinimumLength(2);

            RuleFor(a => a.GrupoAutomovel).NotNull();

            RuleFor(a => a.Combustivel).NotNull();

            RuleFor(a => a.Foto.ImagemBytes).Custom(ValidarArrayBytes());

        
        }

        private Action<byte[], ValidationContext<Automovel>> ValidarArrayBytes()
        {
            return (bytes, context) =>
            {
                if(bytes == null)
                {
                    context.AddFailure("A imagem é obrigatório");
                }

                else if (bytes.Length > Math.Pow(2, 21))
                {
                    context.AddFailure("O tamanho da imagem é superior ao máximo de 2mb");
                }
            };
        }

        private static Action<string, ValidationContext<Automovel>> ValidarPlaca()
        {
            return (placa, context) =>
            {
                if (placa.Length == 7)
                    ValidarPlacaAntiga(placa, context);

                else if (placa.Length == 8)
                    ValidarPlacaNova(placa, context);

                else context.AddFailure("A placa deve ter 7 caracteres no modelo antigo e 8 caracteres no modelo novo");
            };
        }

        private static void ValidarPlacaAntiga(string placa, ValidationContext<Automovel> context)
        {         
            char[] caracteres = placa.ToCharArray();

            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(caracteres[i]))
                {
                    context.AddFailure("Os primeiros 3 caracteres da placa devem ser letras.");
                }
            }

            for (int i = 3; i < 7; i++)
            {
                if (!char.IsDigit(caracteres[i]))
                {
                    context.AddFailure("Os últimos 4 caracteres da placa devem ser dígitos.");
                }
            }
        }

        private static void ValidarPlacaNova(string placa, ValidationContext<Automovel> context)
        {          
            char[] caracteres = placa.ToCharArray();

            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(caracteres[i]))
                {
                    context.AddFailure("Os primeiros 3 caracteres da placa devem ser letras.");
                }
            }

            if (!char.IsDigit(caracteres[3]))
            {
                context.AddFailure("O quarto caracter da placa deve ser um algarismo.");
            }

            if (!char.IsLetter(caracteres[4]))
            {
                context.AddFailure("O quinto caracter da placa deve ser um algarismo.");
            }

            for (int i = 5; i < 8; i++)
            {
                if (!char.IsDigit(caracteres[i]))
                {
                    context.AddFailure("Os últimos 3 caracteres da placa devem ser algarismos.");
                }
            }
        }
    }
}

