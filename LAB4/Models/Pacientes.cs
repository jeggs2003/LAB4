﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LAB4.Models
{
	public class Pacientes : IComparable
	{
		

		[Display(Name = "Nombre")]

		public string Nombre { get; set; }

		[Display(Name = "Apellido")]

		public string Apellido { get; set; }

		[Display(Name = "Edad")]
	
		public string Edad { get; set; }

		[Display(Name = "Especializacion")]
		
		public string Especializacion { get; set; }

		[Display(Name = "Sexo")]
		public string Sexo { get; set; }

		[Display(Name = "Ingreso")]
		
		public string Ingreso { get; set; }

		[Display(Name = "Fecha de Nacimiento")]

		public string Nacimiento { get; set; }

		public int CompareTo(object? obj)
		{
			throw new NotImplementedException();
		}
	}
}
