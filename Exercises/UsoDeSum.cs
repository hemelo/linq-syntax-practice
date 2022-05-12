using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Five
    {
        public ApplicationContext AppContext { get; set; }

        public Five(ApplicationContext appContext)
        {
            AppContext = appContext;
            
            CountDeFaixas("Led Zeppelin");
            SumDaVendaTotalDoArtista("Led Zeppelin");
            SumTotalPorAlbum("Led Zeppelin");
        }   

        private void CountDeFaixas(string artista)
        {
            var quantidade = AppContext.Faixas
                .Count(f => f.Album.Artista.Nome == artista);

            Console.WriteLine("Led Zeppelin tem {0} faixas de música.", quantidade);
        }

        private void SumDaVendaTotalDoArtista(string artista)
        {
            var query = from inf in AppContext.ItemsNotaFiscal
                where inf.Faixa.Album.Artista.Nome == artista
                select new { totalDoItem = inf.Quantidade * inf.PrecoUnitario };

            var totalDoArtista = query.Sum(q => q.totalDoItem);

            Console.WriteLine("Total do artista: R$ {0}", totalDoArtista);
        }

        private void SumTotalPorAlbum(string artista)
        {
            var query = from inf in AppContext.ItemsNotaFiscal
                where inf.Faixa.Album.Artista.Nome == artista
                group inf 
                    by inf.Faixa.Album into agrupado
                let vendasPorAlbum = agrupado.Sum(a => a.Quantidade * a.PrecoUnitario)
                orderby vendasPorAlbum
                    descending
                select new
                {
                    TituloDoAlbum = agrupado.Key.Titulo,
                    TotalPorAlbum = vendasPorAlbum
                };

            foreach (var agrupado in query)
            {
                Console.WriteLine("{0}\t{1}", agrupado.TituloDoAlbum.PadRight(40),agrupado.TotalPorAlbum);
            }
        }
    }
}