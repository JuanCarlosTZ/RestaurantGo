//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantGo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comentario
    {
        public int ID { get; set; }
        public Nullable<int> ID_RESTAURANTE { get; set; }
        public Nullable<int> ID_USUARIO { get; set; }
        public string COMENTARIO1 { get; set; }
    
        public virtual Restaurante Restaurante { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}