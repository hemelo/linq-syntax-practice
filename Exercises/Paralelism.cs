using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZXing;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Eight
    {
        public ApplicationContext AppContext { get; set; }

        private const string Imagens = "Imagens";

        public Eight(ApplicationContext appContext)
        {
            AppContext = appContext;

            Parallelism();
        }

        private void Parallelism() {
            var barcodWriter = new BarcodeWriter{
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 100,
                    Height = 100
                }
            };

            if (!Directory.Exists(Imagens))
                Directory.CreateDirectory(Imagens);

            
            var queryFaixas =
                from f in AppContext.Faixas
                select f;

            var listaFaixas = queryFaixas.ToList();

            Stopwatch stopwatch = Stopwatch.StartNew();

            var queryCodigos =
                listaFaixas
                .AsParallel()
                .Select(f => new
                {
                    Arquivo = string.Format("{0}\\{1}.jpg", Imagens, f.FaixaId),
                    Imagem = barcodWriter.Write(string.Format("aluratunes.com/faixa/{0}", f.FaixaId))
                });

            int contagem = queryCodigos.Count();

            stopwatch.Stop();

            Console.WriteLine("Códigos gerados: {0} em {1} segundos.", contagem,
                stopwatch.ElapsedMilliseconds / 1000.0); 


            foreach (var item in queryCodigos)
            {
                item.Imagem.Save(item.Arquivo, ImageFormat.Jpeg);
            }
            
        }
    }
}