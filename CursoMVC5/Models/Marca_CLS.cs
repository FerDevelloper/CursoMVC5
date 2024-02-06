using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC5.Models
{
	public class Marca_CLS
	{
        [Display (Name = "Id Marca")]
        public int iidMarca { get; set; }
		[Display(Name = "Nombre marca")]
		[Required]
		[StringLength (100,ErrorMessage ="La Longitud maxima es de 100")]
		public string nombre { get; set; }
		[Display(Name = "Descaripcion de la marca")]
		[Required]
		[StringLength(100, ErrorMessage = "La Longitud maxima es de 100")]
		public string descripcion { get; set; }
		public int bhabilitado { get; set; }

		//añado Propiedad (Errores de validacion)

		public string mensaje_error {  get; set; }

    }
}