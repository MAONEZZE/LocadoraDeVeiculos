using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using System.Text;

namespace LocadoraDeVeiculos.InfraEmail
{
    public class GeradorPdf : IGeradorPdf
    {      
        public byte[] GerarPdfEmail(Aluguel aluguel)
        {
            var message = ObterMenssagem(aluguel);

            var document = new Document();

            using var memoryStream = new MemoryStream();

            try
            {
                PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var imagem = aluguel.Automovel.Foto.ImagemBytes;

                if (imagem != null)
                {
                    var stream = new MemoryStream(imagem);

                    document.Add(Image.GetInstance(stream));
                }
           
               var paragraph = new Paragraph(message);

                document.Add(paragraph);

                document.Close();

                return memoryStream.ToArray();
            }
            catch
            {
                return null!;
            }
        }

        private static string ObterMenssagem(Aluguel aluguel)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Detalhes do Aluguel:");
            sb.AppendLine("");
            sb.AppendLine($"Data: {aluguel.DataLocacao:d}");
            sb.AppendLine("");
            sb.AppendLine($"Valor: R$ {aluguel.ValorParcial}");
            return sb.ToString();
        }
    }
}
