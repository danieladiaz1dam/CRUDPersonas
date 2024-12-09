using ASP.Models.ViewModel;
using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            List<PersonaConDepartamento> _genteConDept = new List<PersonaConDepartamento>();

            try
            {
                List<Persona> _gente = PersonaHandlerBL.getPersonas();
                List<Departamento> _departamentos = DepartamentoHandlerBL.getDepartamentos();

                foreach (Persona p in _gente)
                {
                    _genteConDept.Add(new PersonaConDepartamento(p, _departamentos));
                }
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(_genteConDept);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id) { 
            PersonaConDepartamento personaDept = new PersonaConDepartamento();

            try
            {
                Persona p = PersonaHandlerBL.getPersona(id);
                List<Departamento> _departamentos = DepartamentoHandlerBL.getDepartamentos();
                personaDept = new PersonaConDepartamento(p, _departamentos);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(personaDept);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            PersonaConListaDepartamentosVM vm;

            try
            {
                vm = new PersonaConListaDepartamentosVM();
            }
            catch
            {
                return View("Error");
            }

            return View(vm);
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona p)
        {
            try
            {
                PersonaHandlerBL.addPersona(p);
                ViewBag.Msg = $"{p.Nombre} Creada.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            PersonaConListaDepartamentosVM vm = new PersonaConListaDepartamentosVM();
            try
            {
                Persona p = PersonaHandlerBL.getPersona(id);
                vm = new PersonaConListaDepartamentosVM(p);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(vm);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona p)
        {
            try
            {
                PersonaHandlerBL.updatePersona(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            Persona p = PersonaHandlerBL.getPersona(id);
            return View(p);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                PersonaHandlerBL.deletePersona(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
