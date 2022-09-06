using Microsoft.AspNetCore.Mvc;
using proyecto_taller_alto_nivel.Data;

namespace proyecto_taller_alto_nivel.Controllers
{
    public class AuxiliarController : Controller
    {
        PropietarioDatos Peropietario_Datos = new PropietarioDatos();
        VehiculoDatos Vehiculo_Datos = new VehiculoDatos();
        MecanicoDatos Mecanico_Datos = new MecanicoDatos();
        ServicioDatos Serivicio_Datos = new ServicioDatos();    




        public IActionResult GuardarMecanico()
        {
            return View();
        }

        public IActionResult GuardarVehiculo()
        {
            return View();
        }

        public IActionResult GuardarPropietario()
        {
            return View();
        }

        public IActionResult EditarVehiculo()
        {
            return View();
        }
        public IActionResult ListarVehiculo()
        {
            return View();
        }
    }
}
