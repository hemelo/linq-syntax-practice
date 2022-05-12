using System;
using System.Collections.Generic;

namespace Linq.Practice.Shared 
{ 
    public partial class NotaFiscal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NotaFiscal()
        {
            this.ItemNotaFiscals = new HashSet<ItemNotaFiscal>();
        }
    
        public int NotaFiscalId { get; set; }
        public int ClienteId { get; set; }
        public System.DateTime DataNotaFiscal { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public decimal Total { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; }
    }
}
