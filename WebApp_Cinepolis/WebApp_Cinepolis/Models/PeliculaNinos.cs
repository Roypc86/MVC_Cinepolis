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
    
    public partial class PeliculaNinos
    {
        public int Id { get; set; }
        public string Resumen { get; set; }
    
        public virtual Pelicula Pelicula { get; set; }
    }
}
