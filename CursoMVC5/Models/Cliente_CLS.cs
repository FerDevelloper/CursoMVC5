using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC5.Models
{
	public class Cliente_CLS
	{

        [Display(Name = "Id de Cliente")]
        public int Iidcliente { get; set; }

        [Display(Name = "Nombre")]
		[Required]
		[StringLength(100,ErrorMessage ="Maximo 100")]
        public string Nombre { get; set; }

		[Display(Name = "Apellido Paterno")]
		[Required]
		[StringLength(50, ErrorMessage = "Maximo 50")]
		public string ApePaterno { get; set; }

		[Display(Name = "Apellido Materno")]
		[Required]
		[StringLength(50, ErrorMessage = "Maximo 50")]
		public string ApeMaterno { get; set; }

		[Display(Name = "Correo Electronico")]
		[Required]
		[StringLength(200, ErrorMessage = "Maximo 200")]
		[EmailAddress(ErrorMessage ="ingrese un email valido")]
		public string Email { get; set; }

		[Display(Name = "Direccion")]
		[Required]
		[StringLength(200, ErrorMessage = "Maximo 200")]
		public string Direccion { get; set; }

		[Display(Name = "Sexo")]
		[Required]
		public int Iidsexo { get; set; }

		[Display(Name = "Telefono Fijo")]
		[Required]
		[StringLength(10, ErrorMessage = "Maximo 10")]
		public string TelefonoFijo { get; set; }

		[Display(Name = "Telefono Celular")]
		[Required]
		[StringLength(10, ErrorMessage = "Maximo 10")]
		public string TelefonoCelular { get; set; }

        public bool Bhabilitado { get; set; }

		[Display(Name = "Id Usuario")]
		public int IidtipoUsuario { get; set; }

    }
}