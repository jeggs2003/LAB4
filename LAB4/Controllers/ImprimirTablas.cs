using LAB4.Models;
using Microsoft.AspNetCore.Mvc;
using static LAB4.Models.MonticuloBinario;

namespace LAB4.Controllers
{
    [Route("api/[controller]")]
    public class ImprimirTablas : Controller
    {
        [Route("MPacientes")]
        
        public ActionResult MPacientes()
        {
            List<Pacientes> paci = new List<Pacientes>();
            
           paci = MonticuloBinario.Salida();

            return View(paci);
        }


    }
}
