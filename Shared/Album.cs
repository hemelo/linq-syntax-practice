using System;
using System.Collections.Generic;
    
namespace Linq.Practice.Shared 
{
    public partial class Album
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Album()
        {
            this.Faixas = new HashSet<Faixa>();
        }
    
        public int AlbumId { get; set; }
        public string Titulo { get; set; }
        public int ArtistaId { get; set; }
    
        public virtual Artista Artista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faixa> Faixas { get; set; }
    }
}
