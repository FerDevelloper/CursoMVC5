using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace CursoMVC5.Models
{
	public class Sucursal_CLS
	{
        [Display (Name ="Id Sucursal")]
        public int Iidsucursal { get; set; }

		[Display(Name = "Nombre Sucursal")]
		[Required]
		[StringLength (100,ErrorMessage = "Longitud Maxima 100")]
		public string Nombre { get; set; }

		[Display(Name = "Direccion")]
		[Required]
		[StringLength(200, ErrorMessage = "Longitud Maxima 200")]
		public string Direccion { get; set; }

		[Display(Name = "Telefono")]
		[Required]
		[StringLength(1, ErrorMessage = "Longitud Maxima 1")]
		public string Telefono { get; set; }

		[Display(Name = "Email")]
		[Required]
		[StringLength(100, ErrorMessage = "Longitud Maxima 100")]
		[EmailAddress(ErrorMessage ="Correo invalido")]
		public string Email {  get; set; }

		[Display(Name = "Fecha De apertura")]
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyy-mm-dd}",ApplyFormatInEditMode = true)]
		public DateTime FechaApertura { get; set; }

        public int Bhabilitado { get; set; }
    }
}