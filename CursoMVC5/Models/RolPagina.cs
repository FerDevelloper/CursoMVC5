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
    
    public partial class RolPagina
    {
        public int IIDROLPAGINA { get; set; }
        public Nullable<int> IIDROL { get; set; }
        public Nullable<int> IIDPAGINA { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        public virtual Pagina Pagina { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
