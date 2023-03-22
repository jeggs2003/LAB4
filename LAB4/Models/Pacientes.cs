using System.ComponentModel.DataAnnotations;
namespace LAB4.Models
{
	public class Pacientes
	{
		[Display(Name = "Nombre")]
		[Required(AllowEmptyStrings = false, ErrorMessage = " DEBE INGRESAR EL NOMBRE DEL PACIENTE")]
		[StringLength(50)]
		public string Nombre { get; set; }

		[Display(Name = "Apellido")]
		[Required(AllowEmptyStrings = false, ErrorMessage = " DEBE INGRESAR EL APELLIDO DEL PACIENTE")]
		[StringLength(50)]
		public string Apellido { get; set; }

		[Display(Name = "Edad")]
		[Required(AllowEmptyStrings = false, ErrorMessage = " DEBE INGRESAR LA EDAD DEL PACIENTE")]
		[StringLength(50)]
		public int Edad { get; set; }

		[Display(Name = "Especializacion")]
		[Required(AllowEmptyStrings = false, ErrorMessage = " DEBE INGRESAR EL TIPO DE ESPECIALIZACION QUE NECESITA EL PACIENTE")]
		[StringLength(50)]
		public string Esp { get; set; }

		[Display(Name = "Ingreso")]
		[Required(AllowEmptyStrings = false, ErrorMessage = " DEBE INGRESAR COMO INGRESO EL PACIENTE")]
		[StringLength(50)]
		public string Ingreso { get; set; }





	}
}
