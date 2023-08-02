
using System.Drawing.Imaging;

namespace LocadoraDeVeiculos.WinApp.ModuloAutomovel
{
    public class ManipuladorImagem
    {
        public byte[] ConverterParaBytes(Image image)
        {
            using var ms = new MemoryStream();

            image.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

        public Image ConverterParaImagem(byte[] imagemBytes)
        {
            using var ms = new MemoryStream(imagemBytes);

            return Image.FromStream(ms);
        }

        public Image RedimensionarImagem(string imagePath)
        {
            if (!imagePath.EndsWith(".jpg") && !imagePath.EndsWith(".png"))
            {
               throw new Exception("A imagem deve ser em formato jpg ou png.");
            }


            Image imageSelecionada = Image.FromFile(imagePath);

            const int novaLargura = 200;

            if (imageSelecionada.Width > novaLargura)
            {
                double proporcao = (double)novaLargura / imageSelecionada.Width;

                int novaAltura = (int)(proporcao * imageSelecionada.Height);

                var novoTamanho = new Size(novaLargura, novaAltura);

                return new Bitmap(imageSelecionada, novoTamanho);
            }

            return imageSelecionada;
        }
    }
}
