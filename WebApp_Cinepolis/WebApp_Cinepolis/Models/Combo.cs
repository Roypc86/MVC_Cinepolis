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
    using System.ComponentModel.DataAnnotations;

    public partial class Combo
    {
        public int Id { get; set; }
        public Nullable<int> CineId { get; set; }
        [Display(Name = "tipo")]
        public bool EsAdulto { get; set; }

        public string Juguete { get; set; }
        public Nullable<int> TiqueteId { get; set; }
        public int IdCine { get; set; } //ViewBag
        public string Productos { get; set; }
        public bool VistaGeneral { get; set; }//ViewBag
        public virtual Cine Cine { get; set; }
        public virtual Tiquete Tiquete { get; set; }
    }
}
