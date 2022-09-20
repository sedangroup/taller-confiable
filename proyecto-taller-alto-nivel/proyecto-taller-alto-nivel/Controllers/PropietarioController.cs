using Microsoft.AspNetCore.Mvc;
using proyecto_taller_alto_nivel.Data;
using proyecto_taller_alto_nivel.Models;

namespace proyecto_taller_alto_nivel.Controllers
{
    public class PropietarioController : Controller
    {
        PropietarioDatos Propietario_Datos = new PropietarioDatos();
        VehiculoDatos Vehiculo_Datos = new VehiculoDatos();
        MecanicoDatos Mecanico_Datos = new MecanicoDatos();
        ServicioDatos Servicio_Datos = new ServicioDatos();
        SoatDatos Soat_Datos = new SoatDatos();




        public IActionResult ListarServicio(VehiculoModel vehiculo)
        {
            var list = Servicio_Datos.ListarByLicencia(vehiculo);
            return View(list);
        }

        public IActionResult ListarServicios()
        {
            var list = Servicio_Datos.Listar();
            return View(list);
        }

        public IActionResult ObtenerPlacaServicio()
        {
            return View();
        }
        //____________________________________________________________________________________
        public IActionResult ListarSoat(string Licencia)
        {
            var innerQuey = Soat_Datos.ObtenerSoatPlaca(Licencia);
            return View(innerQuey);
        }

        public IActionResult GuardarSoat()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarSoat(SoatModel Soat)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Soat_Datos.Guardar(Soat);

            if (respuesta)
                return RedirectToAction("ListarSoat");
            else
                return View();
        }

        public IActionResult ObtenerSoat()
        {
            return View();
        }

        
    }
}
