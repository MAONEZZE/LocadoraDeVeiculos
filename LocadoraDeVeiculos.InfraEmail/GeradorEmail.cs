using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace LocadoraDeVeiculos.InfraEmail
{
    public class GeradorEmail : IGeradorEmail
    {
        private readonly string? senha = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
     
        public Result EnviarEmail(Aluguel aluguel, byte[] bytesAnexo = null!)
        {
            string emailRemetente = "";

            string tipoEmail = aluguel.EstaAberto ? "Aprovação" : "Finalização";

            var emailMessage = new MailMessage();

            emailMessage.From = new MailAddress(ValidarEndereco(emailRemetente));

            emailMessage.To.Add(new MailAddress(ValidarEndereco(aluguel.Cliente.Email)));

            emailMessage.Subject = $"Detalhes da {tipoEmail} do aluguel do veículo {aluguel.Automovel.Modelo}";

            emailMessage.Body = CorpoEmail();

            if (bytesAnexo != null)
            {
                var anexoStream = new MemoryStream(bytesAnexo);

                var anexo = new Attachment(anexoStream, "Aluguel.pdf", "application/pdf");

                emailMessage.Attachments.Add(anexo);
            }

            try
            {
                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(emailRemetente, senha);

                    smtp.SendAsync(emailMessage, null);
                }

                return Result.Ok().WithSuccess("Email enviado com sucesso");
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message).WithError("Falha ao enviar email");
            }
        }


        private static string ValidarEndereco(string email)
        {
            return email;
        }

        private static string CorpoEmail()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Prezado cliente,");
            sb.AppendLine("");
            sb.AppendLine("Agradecemos pela preferência de nossa locadora de veículos. Estamos felizes em poder atendê-lo e esperamos que você tenha uma experiência agradável.");
            sb.AppendLine("");
            sb.AppendLine("Estamos sempre trabalhando para melhorar nossos serviços e estamos abertos a sugestões. Se você tiver alguma dúvida ou comentário, por favor, não hesite em entrar em contato conosco.");
            sb.AppendLine("");
            sb.AppendLine($"Segue em anexo detalhes do aluguel");
            sb.AppendLine("");
            sb.AppendLine("Atenciosamente,");
            sb.AppendLine("Locadora de Veículos Devagar e Sempre");

            return sb.ToString();
        }
    }
}
