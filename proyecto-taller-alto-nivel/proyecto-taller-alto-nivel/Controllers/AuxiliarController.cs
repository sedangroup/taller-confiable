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
        SoatDatos Soat_Datos = new SoatDatos();


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
        /// ----------------------------------------------------------------------------------
        public IActionResult BuscarCedula(string Identificacion)
        {
            var oCedula = Propietario_Datos.ObtenerCedula(Identificacion);
            return View(oCedula);
        }

        public IActionResult BuscarPropietario(int id_Persona)
        {
            var oCedula = Propietario_Datos.Obtener(id_Persona);
            return View(oCedula);
        }

        /// -----------------------------------------------------------------------------------------
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


        /// -------------------------------------------------------------------------------------
        public IActionResult BuscarMecanico(int id_Mecanico)
        {
            var oMecanico = Mecanico_Datos.ObtenerIdMecanico(id_Mecanico);
            return View(oMecanico);
        }

        public IActionResult BuscarIdMecanico(int id_Persona)
        {
            var oCedula = Mecanico_Datos.Obtener(id_Persona);
            return View(oCedula);
        }
        /// ----------------------------------------------------------------------------------------
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

        public IActionResult ObtenerVehiculo(string Licencia)
        {
            var oLicencia = Vehiculo_Datos.ObtenerPlaca(Licencia);
            return View(oLicencia);
        }

        public IActionResult ObtenerPlaca(int id_Vehiculo)
        {
            var oLicencia = Vehiculo_Datos.Obtener(id_Vehiculo);
            return View(oLicencia);
        }


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
        /// -----------------------------------------------------
        public IActionResult ListarSoat(int id_Vehiculo)
        {
            var innerQuey = Soat_Datos.Listar(id_Vehiculo);
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


        public IActionResult EditarSoat(int id_Soat)
        {
            var oSoat = Soat_Datos.Obtener(id_Soat);
            return View(oSoat);
        }

        [HttpPost]
        public IActionResult EditarSoat(SoatModel oSoat)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Soat_Datos.Editar(oSoat);

            if (respuesta)
                return RedirectToAction("ListarSoat");
            else
                return View();
        }

        public IActionResult EliminarSoat(int id_Soat)
        {

            var oSoat = Soat_Datos.Obtener(id_Soat);
            return View(oSoat);
        }

        [HttpPost]
        public IActionResult EliminarSoat(SoatModel oSoat)
        {
            var respuesta = Soat_Datos.Eliminar(oSoat.id_Soat);

            if (respuesta)
                return RedirectToAction("ListarSoat");
            else
                return View();
        }

        public IActionResult GuardarServicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarServicio(ServicioInnerJoinModel servicio)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Servicio_Datos.Guardar(servicio);

            if (respuesta)
                return RedirectToAction("ListarServicios");
            else
                return View();
        }

        public IActionResult EditarServicio(int idServicio)
        {
            var oSoat = Servicio_Datos.Obtener(idServicio);
            return View(oSoat);
        }

        [HttpPost]
        public IActionResult EditarServicio(ServicioInnerJoinModel servicio)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Servicio_Datos.Editar(servicio);

            if (respuesta)
                return RedirectToAction("ListarServicios");
            else
                return View();
        }


    }
}
