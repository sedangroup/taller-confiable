using Microsoft.AspNetCore.Mvc;

namespace proyecto_taller_alto_nivel.Controllers
{
    public class AuxiliarController : Controller
    {
        public IActionResult GuardarMecanico()
        {
            return View();
        }

        public IActionResult GuardarVehiculo()
        {
            return View();
        }

    }
}
