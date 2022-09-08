using Microsoft.AspNetCore.Mvc;
using proyecto_taller_alto_nivel.Data;
using proyecto_taller_alto_nivel.Models;

namespace proyecto_taller_alto_nivel.Controllers
{
    public class AuxiliarController : Controller
    {
        PropietarioDatos Propietario_Datos = new PropietarioDatos();
        VehiculoDatos Vehiculo_Datos = new VehiculoDatos();
        MecanicoDatos Mecanico_Datos = new MecanicoDatos();
        ServicioDatos Servicio_Datos = new ServicioDatos();


        public IActionResult ListarPropietario()
        {
            return View();
        }
        public IActionResult GuardarPropietario()
        {
            return View();
        }

        public IActionResult EditarPropietario()
        {
            return View();
        }

        public IActionResult EliminarPropietario()
        {
            return View();
        }

        public IActionResult ListarMecanico()
        {
            return View();
        }
        public IActionResult GuardarMecanico()
        {
            return View();
        }

        public IActionResult EditarMecanico()
        {
            return View();
        }

        public IActionResult EliminarMecanico()
        {
            return View();
        }

        public IActionResult ListarVehiculo()
        {
            var innerQuey = Vehiculo_Datos.Listar();
            return View(innerQuey);
        }
        public IActionResult GuardarVehiculo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarVehiculo(VehiculoModel vehiculo)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Vehiculo_Datos.Guardar(vehiculo);

            if (respuesta)
                return RedirectToAction("ListarVehiculo");
            else
                return View();
        }

        public IActionResult EditarVehiculo()
        {
            return View();
        }

        public IActionResult EliminarVehiculo()
        {
            return View();
        }

        public IActionResult AsignarPropietario()
        {
            return View();
        }

        public IActionResult AsignarMecanico()
        {
            return View();
        }

        public IActionResult ListarServicios()
        {
            return View();
        }

        public IActionResult ObtenerServicios()
        {
            return View();
        }
    }
}
