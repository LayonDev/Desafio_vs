//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desafio_vs.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reunion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reunion()
        {
            this.Invitados = new HashSet<Invitados>();
        }
    
        public int id_reunion { get; set; }
        public string titulo { get; set; }
        public string descripción { get; set; }
        public System.DateTime Fecha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitados> Invitados { get; set; }
    }
}
