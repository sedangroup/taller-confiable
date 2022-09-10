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
            var oLista = Propietario_Datos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarPropietario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarPropietario(PropietarioModel oPropietario)
        {
            if (!ModelState.IsValid)
                return View();

        var respuesta = Propietario_Datos.Guardar(oPropietario);

            if (respuesta)
                return RedirectToAction("ListarPropietario");
            else
                return View();
    }

        public IActionResult EditarPropietario(int id_Persona)
        {
            var oPropietario = Propietario_Datos.Obtener(id_Persona);
            return View(oPropietario);
        }

        [HttpPost]
        public IActionResult EditarPropietario(PropietarioModel oPropietario)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Propietario_Datos.Editar(oPropietario);

            if (respuesta)
                return RedirectToAction("ListarPropietario");
            else
                return View();
        }

        public IActionResult EliminarPropietario(int id_Persona)
        {
            var opersona = Propietario_Datos.Obtener(id_Persona);
            return View(opersona);
        }

        [HttpPost]
        public IActionResult EliminarPropietario(PropietarioModel oPropietario)
        {
            var respuesta = Propietario_Datos.Eliminar(oPropietario.id_Persona);
            
            if (respuesta)
                return RedirectToAction("ListarPropietario");
            else
                return View();
        }
        /// -----------------------------------------------------
        public IActionResult ListarMecanico()
        {
            var oLista = Mecanico_Datos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarMecanico()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarMecanico(MecanicoModel oMecanico)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Mecanico_Datos.Guardar(oMecanico);

            if (respuesta)
                return RedirectToAction("ListarMecanico");
            else
                return View();
        }

        public IActionResult EditarMecanico(int id_Persona)
        {
            var oMecanico = Mecanico_Datos.Obtener(id_Persona);
            return View(oMecanico);
        }

        [HttpPost]
        public IActionResult EditarMecanico(MecanicoModel oMecanico)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Mecanico_Datos.Editar(oMecanico);

            if (respuesta)
                return RedirectToAction("ListarMecanico");
            else
                return View();
        }

        public IActionResult EliminarMecanico(int id_Persona)
        {

            var oMecanico = Mecanico_Datos.Obtener(id_Persona);
            return View(oMecanico);
        }

        [HttpPost]
        public IActionResult EliminarMecanico(MecanicoModel oMecanico)
        {
            var respuesta = Mecanico_Datos.Eliminar(oMecanico.id_Persona);

            if (respuesta)
                return RedirectToAction("ListarMecanico");
            else
                return View();
        }
        /// -----------------------------------------------------
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
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        public IActionResult ObtenerVehiculo(string Licencia)
        {
            var oLicencia = Vehiculo_Datos.ObtenerPlaca(Licencia);
            return View(oLicencia);
        }

        [HttpPost]
        public IActionResult ObtenerVehiculo(VehiculoModel oLicencia)
        {
            if (!ModelState.IsValid)
                return View();
             
            var respuesta = Vehiculo_Datos.Editar(oLicencia);

            if (respuesta)
                return RedirectToAction("ListarVehiculo");
            else
                return View();
        }
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        public IActionResult EditarVehiculo(int id_Vehiculo)
        {
            var oVehiculo = Vehiculo_Datos.Obtener(id_Vehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult EditarVehiculo(VehiculoModel oVehiculo)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Vehiculo_Datos.Editar(oVehiculo);

            if (respuesta)
                return RedirectToAction("ListarVehiculo");
            else
                return View();
        }

        public IActionResult EliminarVehiculo(int id_Vehiculo)
        {

            var oVehiculo = Vehiculo_Datos.Obtener(id_Vehiculo);
            return View(oVehiculo);
        }

        [HttpPost]
        public IActionResult EliminarVehiculo(VehiculoModel oVehiculo)
        {
            var respuesta = Vehiculo_Datos.Eliminar(oVehiculo.id_Vehiculo);

            if (respuesta)
                return RedirectToAction("ListarVehiculo");
            else
                return View();
        }
            /// -----------------------------------------------------
        
    }
}
