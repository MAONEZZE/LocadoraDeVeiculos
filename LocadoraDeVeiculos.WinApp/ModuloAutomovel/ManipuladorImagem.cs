
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
