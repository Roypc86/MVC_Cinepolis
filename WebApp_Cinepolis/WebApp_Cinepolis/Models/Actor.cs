//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp_Cinepolis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Actor()
        {
            this.Relacion_Pelicula_Actor = new HashSet<Relacion_Pelicula_Actor>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_1 { get; set; }
        public string Apellido_2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Relacion_Pelicula_Actor> Relacion_Pelicula_Actor { get; set; }
    }
}
