using System;
using System.Collections.Generic;

namespace Linq.Practice.Shared 
{
    public partial class Faixa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faixa()
        {
            this.ItemNotaFiscals = new HashSet<ItemNotaFiscal>();
            this.Playlists = new HashSet<Playlist>();
        }
    
        public int FaixaId { get; set; }
        public string Nome { get; set; }
        public Nullable<int> AlbumId { get; set; }
        public int TipoMidiaId { get; set; }
        public Nullable<int> GeneroId { get; set; }
        public string Compositor { get; set; }
        public int Milissegundos { get; set; }
        public Nullable<int> Bytes { get; set; }
        public decimal PrecoUnitario { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual TipoMidia TipoMidia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemNotaFiscal> ItemNotaFiscals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
