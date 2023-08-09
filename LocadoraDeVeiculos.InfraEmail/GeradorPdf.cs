using iTextSharp.text;
using iTextSharp.text.pdf;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoDeCobranca;
using System.Text;


namespace LocadoraDeVeiculos.InfraEmail
{
    public class GeradorPdf : IGeradorPdf
    {
        public byte[] GerarPdfEmail(Aluguel aluguel)
        {
            var message = GerarCorpoPdf(aluguel);

            var document = new Document();

            using var memoryStream = new MemoryStream();

            try
            {
                PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var cabecalho = new Paragraph("Locadora de Veículos - Devagar e Sempre", new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.UNDERLINE))
                {
                    Alignment = PdfContentByte.ALIGN_CENTER
                };

                document.Add(cabecalho);

                var imagem = aluguel.Automovel.Foto.ImagemBytes;

                if (imagem != null)
                {
                    var stream = new MemoryStream(imagem);
                    var img = Image.GetInstance(stream);
                    img.ScaleToFit(120f, 120f);
                    img.Alignment = PdfContentByte.ALIGN_CENTER;
                    document.Add(img);
                }

                cabecalho = new Paragraph("Detalhes do Aluguel", new Font(Font.FontFamily.TIMES_ROMAN, 10, Font.UNDERLINE));

                document.Add(cabecalho);
               
                var paragraph = new Paragraph(message, new Font(Font.FontFamily.TIMES_ROMAN, 10));

                document.Add(paragraph);

                document.AddCreationDate();

                document.Close();

                return memoryStream.ToArray();
            }
            catch
            {
                return null!;
            }
        }


        private static string GerarCorpoPdf(Aluguel aluguel)
        {
            var tipo = aluguel.Cliente.TipoCliente == Dominio.Compartilhado.TipoClienteEnum.CPF ? "CPF" : "CNPJ";

            var sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine($"Funcionário: {aluguel.Funcionario.Nome}");
            sb.AppendLine("");
            sb.AppendLine($"Cliente: {aluguel.Cliente.Nome} - {tipo}: {aluguel.Cliente.Documento}");
            sb.AppendLine($"Condutor: {aluguel.Condutor.Nome} - CNH: {aluguel.Condutor.Cnh}");
            sb.AppendLine($"Data Locação: {aluguel.DataLocacao:d}");
            sb.AppendLine("");
            sb.AppendLine($"Plano de cobrança: {aluguel.PlanoDeCobranca.TipoPlano}");
            sb.AppendLine("");
            sb.AppendLine(MostrarPlanoCobranca(aluguel));
            sb.AppendLine($"Grupo Automóvel: {aluguel.GrupoAutomovel}");
            sb.AppendLine("");
            sb.AppendLine($"--- Automóvel Locado --- ");
            sb.AppendLine("");
            sb.AppendLine($" ° Modelo: {aluguel.Automovel.Modelo}");
            sb.AppendLine($" ° Marca: {aluguel.Automovel.Marca}");
            sb.AppendLine($" ° Cor: {aluguel.Automovel.Cor}");
            sb.AppendLine($" ° Ano: {aluguel.Automovel.Ano}");
            sb.AppendLine($" ° Quilometragem: {aluguel.Automovel.Quilometragem}");
            sb.AppendLine($" ° Combustível: {aluguel.Automovel.Combustivel}");
            sb.AppendLine($" ° Capacidade de Combustivel: {aluguel.Automovel.CapacidadeDeCombustivel}");
            sb.AppendLine("");
            sb.AppendLine("--- Taxas e Serviços ---");
            sb.AppendLine("");

            int contadorTaxas = 1;
            foreach(var taxa in aluguel.TaxasServicos)
            {
                sb.AppendLine($"{contadorTaxas} - {taxa.Nome}\t - R$ {taxa.Preco}");
                contadorTaxas++;
            }

            sb.AppendLine("");
            sb.AppendLine($"Data prevista para devolução: {aluguel.DataDevolucaoPrevista:d}");
            sb.AppendLine($"Data devolução: {(aluguel.EstaAberto ? "Em aberto" : $"{aluguel.DataDevolucao:d}")}");
            sb.AppendLine("");
            sb.AppendLine($"Cupom: {(aluguel.Cupom == null ? "Sem Cupom" : $"{aluguel.Cupom.Nome} - R$ {aluguel.Cupom.Valor} - Parceiro: {aluguel.Cupom.Parceiro.Nome}")}");
            sb.AppendLine($"Valor Parcial: R$ {aluguel.ValorTotalPrevisto}");
            sb.AppendLine($"Valor Total: R$ {(aluguel.ValorTotal == 0 ? "Em aberto" : $"{aluguel.ValorTotal}")}");

            return sb.ToString();
        }

        private static string MostrarPlanoCobranca(Aluguel aluguel)
        {
            var sb = new StringBuilder();

            string valorDiaria = aluguel.PlanoDeCobranca.PrecoDiaria.ToString();
            string precoKm = aluguel.PlanoDeCobranca.PrecoKm.ToString();
            string kmDispoiveis = aluguel.PlanoDeCobranca.KmDisponivel.ToString();


            if (aluguel.PlanoDeCobranca.TipoPlano == TipoPlanoEnum.Diario)
            {
                sb.AppendLine($"Valor diária: R$ {valorDiaria}");
                sb.AppendLine($"Valor por Km rodado: R$ {precoKm}");
            }
            else if (aluguel.PlanoDeCobranca.TipoPlano == TipoPlanoEnum.Controlado)
            {
                sb.AppendLine($"Valor diária: R$ {valorDiaria}");
                sb.AppendLine($"Km disponíveis: R$ {kmDispoiveis}");
            }
            else if (aluguel.PlanoDeCobranca.TipoPlano == TipoPlanoEnum.Livre)
            {
                sb.AppendLine($"Valor diária: R$ {valorDiaria}");
            }

            return sb.ToString();

        }
    }
}




