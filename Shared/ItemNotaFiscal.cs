using System;
using System.Collections.Generic;

namespace Linq.Practice.Shared 
{
    public partial class ItemNotaFiscal
    {
        public int ItemNotaFiscalId { get; set; }
        public int NotaFiscalId { get; set; }
        public int FaixaId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    
        public virtual Faixa Faixa { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
    }
}
