//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CursoMVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DETALLEVENTA
    {
        public int IIDETALLEVENTA { get; set; }
        public Nullable<int> IIDVENTA { get; set; }
        public Nullable<int> IIDVIAJE { get; set; }
        public Nullable<int> IIDBUS { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        public virtual Bus Bus { get; set; }
        public virtual VENTA VENTA { get; set; }
        public virtual Viaje Viaje { get; set; }
    }
}
