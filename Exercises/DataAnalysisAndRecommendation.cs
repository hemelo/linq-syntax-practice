using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Linq.Practice.Shared; 

namespace Linq.Practice.Exercises
{
    class Seven
    {
        public ApplicationContext AppContext { get; set; }

        public Seven(ApplicationContext appContext)
        {
            AppContext = appContext;

            AffinityAnalisysWithSelfJoin("Smells Like Teen Spirit");
        }

        private void AffinityAnalisysWithSelfJoin(string produto)
        {
            var faixaIds = AppContext.Faixas
                .Where(f => f.Nome == produto).Select(f => f.FaixaId);

            var query = from comprouItem in AppContext.ItemsNotaFiscal
                join comprouTambem in AppContext.ItemsNotaFiscal
                    on comprouItem.NotaFiscalId equals comprouTambem.NotaFiscalId
                where faixaIds.Contains(comprouItem.FaixaId)
                    && comprouItem.FaixaId != comprouTambem.FaixaId
                select comprouTambem;
        }
    }
}