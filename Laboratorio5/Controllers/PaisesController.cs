using Laboratorio5.Handlers;
using Laboratorio5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorio5.Controllers
{
    public class PaisesController : Controller
    {
        public IActionResult Index()
        {
            PaisesHandler paisesHandler = new PaisesHandler();
            var paises = paisesHandler.ObtenerPaises();
            ViewBag.MainTitle = "Lista de países";
            return View(paises);
        }

        [HttpGet]
        public IActionResult CrearPais()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearPais(PaisModel pais)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    PaisesHandler paisesHandler = new PaisesHandler();
                    ViewBag.ExitoAlCrear = paisesHandler.CrearPais(pais);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El país" + "" + pais.Nombre + "fue creado con éxito";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el país";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarPais(int? identificador)
        {
            ActionResult vista;
            try 
            {
                var paisesHandler = new PaisesHandler();
                var pais = paisesHandler.ObtenerPaises().Find(model => model.Id == identificador);
                if(pais == null)
                {
                    vista = RedirectToAction("Index");
                }
                else 
                {
                    vista = View(pais);
                }
            }
            catch 
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult EditarPais(PaisModel pais)
        {
            try
            {
                var paisesHandler = new PaisesHandler();
                paisesHandler.EditarPais(pais);
                return RedirectToAction("Index", "Paises");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult BorrarPais(int? identificador)
        {
            ActionResult vista;
            try
            {
                var paisesHandler = new PaisesHandler();
                var pais = paisesHandler.ObtenerPaises().Find(model => model.Id == identificador);
                if (pais == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(pais);
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult BorrarPais(PaisModel pais)
        {
            try
            {
                var paisesHandler = new PaisesHandler();
                paisesHandler.BorrarPais(pais);
                return RedirectToAction("Index", "Paises");
            }
            catch
            {
                return View();
            }
        }
    }
}
