using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC5.Models
{
	public class Viaje_CLS
	{

        [Display (Name = "Id de Viaje")]
        public int iidviaje { get; set; }

		[Display(Name = "Lugar de Origen")]
		[Required]
		public int iidLugarOrigen { get; set; }

		[Display(Name = "Lugar del destino")]
		[Required]
		public int iidLugarDestino { get; set; }

		[Display(Name = "Precio")]
		[Required]
		public double precio { get; set; }

		[Display(Name = "Fecha de viaje")]
		[Required]
		public DateTime fechaViaje { get; set; }

		[Display(Name = "Bus")]
		[Required]
		public int iidbus { get; set; }

		[Display(Name = "Numero de asientos")]
		[Required]
		public int numeroDeAsientos { get; set; }


		//propiedaes adicionales

		[Display(Name = "Lugar de Origen")]
		public string nombreLugarOrigen { get; set; }

		[Display(Name = "Lugar del destino")]

		public string nombreLugarDestino { get; set; }

		[Display(Name = "Bus")]
		public string nombreBus { get; set; }

	}
}