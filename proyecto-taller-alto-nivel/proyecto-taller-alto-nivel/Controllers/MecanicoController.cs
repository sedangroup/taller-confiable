using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_taller_alto_nivel.Data;
using proyecto_taller_alto_nivel.Models;

namespace proyecto_taller_alto_nivel.Controllers
{

    public class MecanicoController : Controller
    {
        RevisionDatos Revision_Datos = new RevisionDatos();
        RepuestosDatos Repuesto_Datos = new RepuestosDatos();
        ServicioDatos Servicio_Datos = new ServicioDatos();
        // GET: MecanicoController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaServiciosMecanico()
        {
            var list = Servicio_Datos.Listar();
            return View(list);
        }

        public ActionResult ListaServiciosId(MecanicoModel mecanico)
        {
            var list = Servicio_Datos.ListarById(mecanico);
            return View(list);
        }

        public ActionResult ObtenerServicioPlaca()
        {

            return View();
        }

        public ActionResult ObtenerServicioMecanico()
        {

            return View();
        }

        public ActionResult GuardarRevision()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarRevision(RevisionModel Revision)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Revision_Datos.Guardar(Revision);

            if (respuesta)
                return RedirectToAction("ListaServiciosMecanico");
            else
                return View();

        }
        public ActionResult GuardarRepuesto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarRepuesto(RepuestosModel Repuesto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = Repuesto_Datos.Guardar(Repuesto);

            if (respuesta)
                return RedirectToAction("ListaServiciosMecanico");
            else
                return View();

        }

        public ActionResult ListarRevisiones()
        {
            var list = Revision_Datos.Listar();
            return View(list);
        }

        public IActionResult ListarServicio(VehiculoModel vehiculo)
        {
            var list = Servicio_Datos.ListarByLicencia(vehiculo);
            return View(list);
        }
        public ActionResult ListarRepuestos()
        {
            var list = Repuesto_Datos.Listar();
            return View(list);
        }

        

        public IActionResult EditarRevision(int idRevision)
        {
            var result = Revision_Datos.Obtener(idRevision);
            return View(result);
        }

        [HttpPost]
        public IActionResult EditarRevision(RevisionModel revision)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Revision_Datos.Editar(revision);

            if (respuesta)
                return RedirectToAction("ListarRevisiones");
            else
                return View();
        }
        public IActionResult EditarRepuesto(int Repuesto)
        {
            var result = Repuesto_Datos.Obtener(Repuesto);
            return View(result);
        }

        [HttpPost]
        public IActionResult EditarRepuesto(RepuestosModel Repuesto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Repuesto_Datos.Editar(Repuesto);

            if (respuesta)
                return RedirectToAction("ListarRepuestos");
            else
                return View();
        }
        public IActionResult EditarReparacion(int idRevision)
        {
            var result = Revision_Datos.Obtener(idRevision);
            return View(result);
        }

        [HttpPost]
        public IActionResult EditarReparacion(RevisionModel revision)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = Revision_Datos.Editar(revision);

            if (respuesta)
                return RedirectToAction("ListarRevisiones");
            else
                return View();
        }
    }
}
