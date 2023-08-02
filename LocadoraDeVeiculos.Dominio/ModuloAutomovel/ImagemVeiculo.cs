using System;
namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class ImagemVeiculo
    {
       
        public string NomeArquivo { get; set; } 

        public byte[] ImagemBytes { get; set; }

        public ImagemVeiculo(byte[] imagemBytes)
        {
            NomeArquivo = Guid.NewGuid().ToString() + ".jpg";

            ImagemBytes = imagemBytes;
        }
    }
}
