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
    using System.ComponentModel.DataAnnotations;

    public partial class Restaurante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurante()
        {
            this.Comentario = new HashSet<Comentario>();
            this.RestauranteValoracion = new HashSet<RestauranteValoracion>();
            this.RestauranteComida = new HashSet<RestauranteComida>();
            this.UsuarioRestaurante = new HashSet<UsuarioRestaurante>();
        }
    
        public int ID { get; set; }

        [Required]
        public string NOMBRE { get; set; }
        [Required]
        [Display(Name = "DIRECCI�N")]
        public string DIRECCION { get; set; }

        [Display(Name = "UBICACI�N")]
        public string UBICACION { get; set; }

        [Display(Name = "VALORACI�N")]
        public int VALORACION { get; set; }

        public int PRECIO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comentario> Comentario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestauranteValoracion> RestauranteValoracion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RestauranteComida> RestauranteComida { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioRestaurante> UsuarioRestaurante { get; set; }
    }
}
