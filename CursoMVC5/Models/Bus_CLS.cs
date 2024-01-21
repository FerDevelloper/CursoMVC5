using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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