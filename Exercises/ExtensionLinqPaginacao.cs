using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Six
    {
        public ApplicationContext AppContext { get; set; }

        public Six(ApplicationContext appContext)
        {
            AppContext = appContext;
            
            CalculandoMedianaUsandoExtension();
            UtilizandoPaginacaoCustomizada();
        }   

        private void CalculandoMedianaUsandoExtension()
        {
            var vendaMediana = AppContext.NotasFiscais.Mediana(ag => ag.Total);
            Console.WriteLine("Venda Mediana: R$ {0}", vendaMediana);
        }

        private void UtilizandoPaginacaoCustomizada()
        {
            var paginated = AppContext.Albums.Paginado(5, 10);

            foreach(var item in paginated.Results)
            {
                Console.WriteLine("Album {0} de {1}", item.Titulo, item.Artista.Nome);
            }
        }
    }

    public static class Extensions
    {
        public static decimal Mediana<TSource>(this IQueryable<TSource> origem, Expression<Func<TSource, decimal>> selector)
        {
            int contagem = origem.Count();

            var funcSeletor = selector.Compile();
            var ordenado = origem
                .Select(selector)
                .OrderBy(x => x);

            var elementoCentral_1 = ordenado.Skip((contagem - 1) / 2).First();
            var elementoCentral_2 = ordenado.Skip(contagem / 2).First();

            decimal mediana = (elementoCentral_1 + elementoCentral_2) / 2;

            return mediana;
        }

        public static PagedResult<T> Paginado<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {  
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int) Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }
    }

   
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public int FirstRowOnPage
        {
            get { return (CurrentPage - 1) * PageSize + 1; }
        }
        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, RowCount); }
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }
        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}