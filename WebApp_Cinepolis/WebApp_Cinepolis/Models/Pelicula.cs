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
    
    public partial class Pelicula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pelicula()
        {
            this.Horario = new HashSet<Horario>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Director { get; set; }
        public bool EsAdultos { get; set; }
        public string Acciones { get; set; }
        public string Actores { get; set; }
        public string Resumen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Horario> Horario { get; set; }
    }
}
