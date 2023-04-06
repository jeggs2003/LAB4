using Microsoft.AspNetCore.Mvc;
using LAB4.Models;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LAB4.Controllers
{
	public class AvlController : Controller
	{
		ArbolAvl<Pacientes> arbol = new ArbolAvl<Pacientes>();


		// GET: Carro
		public ActionResult Index()
		{
			return View(arbol);
		}

		// CREAR PACIENTE
		[HttpPost]
		public ActionResult Create(string Nombre, string Apellido, string Edad, string Especializacion, string Ingreso, string Nacimiento)
		{
			try
			{
				// NUEVO PACIENTE
				Pacientes paciente = new Pacientes
				{
					Nombre = Nombre,
					Apellido = Apellido,
					Edad = Edad,
					Especializacion = Especializacion,
					Ingreso = Ingreso,
					Nacimiento = Nacimiento
				};

				// PACIENTE AL ARBOL 
				arbol.Agregar(paciente);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}



	}
}
