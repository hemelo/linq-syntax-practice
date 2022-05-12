using System;
using System.Collections.Generic;

namespace Linq.Practice.Shared 
{
    public partial class TipoMidia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoMidia()
        {
            this.Faixas = new HashSet<Faixa>();
        }
    
        public int TipoMidiaId { get; set; }
        public string Nome { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
