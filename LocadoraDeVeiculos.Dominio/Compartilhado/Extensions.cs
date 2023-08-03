using System.ComponentModel;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;

            return "Anotação não informada";
        }
    }

    public static class ValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> NaoPodeCaracteresEspeciais<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CaracteresEspeciasValidador<T>());
        }
    }

}
