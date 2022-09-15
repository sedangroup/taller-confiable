using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_taller_alto_nivel.Data;
using proyecto_taller_alto_nivel.Models;

namespace proyecto_taller_alto_nivel.Controllers
{
    public class MecanicoController : Controller
    {
        ServicioDatos Servicio_Datos = new ServicioDatos();
        // GET: MecanicoController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaServiciosMecanico(MecanicoModel mecanico)
        {
            var list = Servicio_Datos.ListarByDocumento(mecanico);
            return View(list);
        }

        public ActionResult ObtenerServicioDocumento()
        {
            
            return View();
        }

    }
}
