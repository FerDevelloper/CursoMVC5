using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace CursoMVC5.Models
{
	public class Bus_CLS
	{
		[Display(Name = "Id de bus")]
		[Required]
		public int IidBus { get; set; }

		[Display(Name = "Id de Sucursal")]
		[Required]
		public int IidSucursal { get; set; }

		[Display(Name = "Id de Tipo bus")]
		[Required]
		public int IidTipoBus { get; set; }

		[Display(Name = "Id de Tipo bus")]		
		[StringLength(100,ErrorMessage ="La Longitud maxima es de 100")]
		public string placa { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (IidTipoBus % 2 == 0) // Si IidTipoBus es par
			{
				if (string.IsNullOrEmpty(placa))
				{
					yield return new ValidationResult("El campo Placa es obligatorio cuando Id de Tipo bus es par.", new[] { nameof(placa) });
				}
			}
		}


		[Display(Name = "Fecha de Compra")]
		[Required]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "0:yyyy-MM-dd", ApplyFormatInEditMode = true)]
		public DateTime FechaCompra { get; set; }

		[Display(Name = "Id de Modelo")]
		[Required]
		public int IidModelo {  get; set; }

		[Display(Name = "Numero de filas")]
		[Required]
		public int NumeroFilas { get; set; }

		[Display(Name = "Numero de Columnas")]
		[Required]
		public int NumeroColumnas { get; set; }

		public int BHabilitado { get; set; }

		[Display(Name = "Observacion")]
		[Required]
		public string Observacion { get; set; }

		[Display(Name = "Id de Marca")]
		[Required]
		public int IidMarca { get; set; }

		//Propiedades adicionales
		[Display(Name = "Sucursal")]
		[Required]
		public string NombreSucursal { get; set; }

		[Display(Name = "Bus")]
		[Required]
		public string NombreTipoBus { get; set; }

		[Display(Name = "Modelo")]
		[Required]
		public string NombreModelo { get; set; }

		
	}
}