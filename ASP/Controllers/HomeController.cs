using ENT;
using BL;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Persona> gente = PersonaHandlerBL.getPersonas();
            return View(gente);
        }

        public IActionResult Departsss()
        {
            List<Departamento> departamentos = DepartamentoHandlerBL.getDepartamentos();
            return View(departamentos);
        }

        public IActionResult Persona(int id)
        {
            Persona p = PersonaHandlerBL.getPersona(id);
            return View(p);
        }
    }
}
