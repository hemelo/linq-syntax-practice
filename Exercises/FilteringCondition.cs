using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Four
    {
        public ApplicationContext AppContext { get; set; }

        public Four(ApplicationContext appContext)
        {
            AppContext = appContext;

            FilteringByCondition("Led Zeppelin", "Graffiti");
            FilteringByCondition("Led Zeppelin");
        }   

        private void FilteringByCondition(string artista, string? album = null)
        {
            // Filtrando faixas por álbum
            var query = from f in AppContext.Faixas
                where f.Album.Artista.Nome.Contains(artista)
                    && (!string.IsNullOrEmpty(album) ? f.Album.Titulo.Contains(album) : true)
                orderby f.Album.Titulo, f.Nome
                select f;

            foreach (var faixa in query)
            {
                Console.WriteLine("{0}\t{1}", faixa.Album.Titulo.PadRight(40), faixa.Nome);
            }
        }
    }
}