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
    
    public partial class ComboNino
    {
        public int ComboId { get; set; }
        public Nullable<int> JugueteId { get; set; }
    
        public virtual Combo Combo { get; set; }
        public virtual Juguete Juguete { get; set; }
    }
}
