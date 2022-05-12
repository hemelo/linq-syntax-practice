using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Three
    {
        public ApplicationContext AppContext { get; set; }

        public Three(ApplicationContext appContext)
        {
            AppContext = appContext;

            SimpleJoinUsingEntityFramework("Led Zeppelin");
            TakeUsingEntityFramework();
            DontUseJoinEntityFramework("Led Zeppelin");
        }
        
        private void SimpleJoinUsingEntityFramework(string nome)
        {
            var query = from a in AppContext.Artistas
                join alb in AppContext.Albums
                    on a.ArtistaId equals alb.ArtistaId
                where a.Nome.Contains(nome)
                select new
                {
                    NomeArtista = a.Nome,
                    NomeAlbum = alb.Titulo
                };

            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}", item.NomeArtista, item.NomeAlbum);
            }
        }

        /**
        * O take é interpretado antes da Query SQL, fazendo com que seja gasto menos recurso pra usar o banco de dados
        */
        private void TakeUsingEntityFramework()
        {
            var query = from g in AppContext.Generos
                join f in AppContext.Faixas
                    on g.GeneroId equals f.GeneroId
                select new { f, g };

            // Paginação
            query = query.Take(10);

            foreach (var item in query)
            {
                Console.WriteLine("{0}\t{1}", item.f.Nome, item.g.Nome);
            }
        }
        
        /**
        * Evitando uso de Join utilizando o pattern de navegação entre classes
        */
        private void  DontUseJoinEntityFramework(string nome)
        {
            var query = from alb in AppContext.Albums
                where alb.Artista.Nome.Contains(nome)
                select new
                {
                    NomeArtista = alb.Artista.Nome,
                    NomeAlbum = alb.Titulo
                };

                foreach (var album in query)
                {
                    Console.WriteLine("{0}\t{1}", album.NomeArtista, album.NomeAlbum);
                }
        }
    }
}
