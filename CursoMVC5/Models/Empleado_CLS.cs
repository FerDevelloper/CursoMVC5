using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC5.Models
{
	public class Empleado_CLS
	{
		[Display(Name ="Id de empleado")]
        public int IidEmpleado { get; set; }

		[Display(Name = "Nombre")]
		[Required]
		[StringLength(100)]
		public string Nombre { get; set; }

		[Display(Name = "Apeido Paterno")]
		[Required]
		[StringLength(100)]
		public string ApPaterno { get; set;}

		[Display(Name = "Apeido Materno")]
		[Required]
		[StringLength(100)]
		public string ApMaterno { get; set; }

		[Display(Name = "Fecha de Contrato")]
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "0:yyyy-MM-dd",ApplyFormatInEditMode =true)]
		public DateTime FechaContrato { get; set; }


		[Display(Name = "Sueldo")]
		[Required]
		[Range(0,10000,ErrorMessage ="Fuera de Rango")]
        public decimal Sueldo { get; set; }

        [Display(Name = "Tipo Usuario")]
		[Required]

		public int IidTipoUsuario {  get; set; }

		[Display(Name = "Tipo Contrato")]
		[Required]
		public int IidTipoContrato { get; set; }

		[Display(Name = "Sexo")]
		[Required]
		public int IidSexo { get; set; }

		public int BHabilitado { get; set; }

		/////Propiedades Adicionales
		///
		[Display(Name = "Tipo Contrato")]
		public string NombreTipoContrato { get; set; }

		[Display(Name = "Tipo Usuario")]
		public string NombreTipoUsuario { get; set; }



	}
}