using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB4.Models;


namespace LAB4.Controllers
{

	[Route("[controller]")]
	public class AgregarArchivoController : Controller
	{


		public void AgregarPaciente(Pacientes pacientes) 
		{
			
			
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
