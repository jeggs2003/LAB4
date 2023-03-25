using System.ComponentModel.DataAnnotations;
namespace LAB4.Models
{
	public class Pacientes
	{
		[Display(Name = "Nombre")]

		public string Nombre { get; set; }

		[Display(Name = "Apellido")]

		public string Apellido { get; set; }

		[Display(Name = "Edad")]
	
		public int Edad { get; set; }

		[Display(Name = "Especializacion")]
		
		public string Especializacion { get; set; }

		[Display(Name = "Ingreso")]
		
		public string Ingreso { get; set; }

		[Display(Name = "Fecha de Nacimiento")]

		public DateTime Nacimiento { get; set; }






	}
}
