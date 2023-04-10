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
		public List <Pacientes> pacientes = new List<Pacientes>();
		public ArbolAvl<Pacientes> arbolp = new ArbolAvl<Pacientes>();
		public EstructuradePriorizacion nep = new EstructuradePriorizacion();


		public void Agregar(Pacientes pacientes) 
		{
			nep.calculo(pacientes);
		}

		public Pacientes paciente = new Pacientes();


		public Pacientes RegistrarPaciente(string NombreP, string ApellidoP, string NacimientoP, string SexoP, string EdadP, string EspecializacionP, string IngresoP)
		{
			paciente.Nombre = NombreP;
			paciente.Apellido = ApellidoP;
			paciente.Edad = EdadP;
			paciente.Especializacion = EspecializacionP;
			paciente.Sexo = SexoP;
			paciente.Ingreso = IngresoP;
			paciente.Nacimiento= NacimientoP;

			return paciente;

		}
		
		static public void AgregarEnOrden(NodoAvl nodo, List<Pacientes> lista)
		{
			if (nodo != null)
			{
				AgregarEnOrden(nodo.SubarbolIzquierdo, lista); // Recorre subárbol izquierdo
				lista.Add(nodo.Pacientes); // Agrega valor actual a la lista
				AgregarEnOrden(nodo.SubarbolDerecho, lista); // Recorre subárbol derecho
			}
		}

		[HttpPost("subirarchivo")]
		public IActionResult SubirArchivo(IFormFile archivo)
		{
			if (archivo != null)
			{
				try
				{
					//Crear una copia del archivo recibido
					string ruta = Path.Combine(Path.GetTempPath(), archivo.Name);
					using (var stream = new FileStream(ruta, FileMode.Create))
					{
						archivo.CopyTo(stream); //Copiar el contenido del archivo
					}

					//Leer el arhivo
					string informacionArchivo = System.IO.File.ReadAllText(ruta);
					//Obtener lineas del archivo y llenar lista
					foreach (string linea in informacionArchivo.Split('\n'))
					{
						if (!string.IsNullOrEmpty(linea))
						{
							//Extraer la informacion de cada persona
							string[] FilaActual = linea.Split(',');

							Agregar(RegistrarPaciente(FilaActual[0], FilaActual[1], FilaActual[2], FilaActual[3], FilaActual[4], FilaActual[5], FilaActual[6]));

						}
					}
				}
				catch (Exception e)
				{
					ViewBag.Error = "Error al leer el archivo" + e.Message;
				}
			}
			else
			{
				ViewBag.Error = "No se ha ingresado la ruta de archivo";
			}
			
			return View();
		}



        [Route("SubirArchivo")]

        public IActionResult SubirArchivo()
		{
			return View();
		}
	}
}
