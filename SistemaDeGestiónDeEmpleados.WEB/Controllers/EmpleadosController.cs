using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestiónDeEmpleados.BL;
using SistemaDeGestiónDeEmpleados.MODEL;

namespace SistemaDeGestiónDeEmpleados.WEB.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly GestorDeEmpleados gestor;

        public EmpleadosController(GestorDeEmpleados gestor)
        {
            this.gestor = gestor;
        }

        // GET: Empleados
        public IActionResult Index(string busqueda = "", int pagina = 1)
        {
            if (pagina < 1)
                pagina = 1;

            int cantidadRegistrosPorPagina = 5;

            var empleados = gestor.ObtenerEmpleados(pagina, cantidadRegistrosPorPagina, busqueda);
            int totalRegistros = gestor.ObtenerTotalRegistros(busqueda);

            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / cantidadRegistrosPorPagina);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.TotalRegistros = totalRegistros;

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            gestor.CrearEmpleado(empleado);
            return RedirectToAction(nameof(Index));
        }

        // GET: Empleados/Edit/5
        public IActionResult Edit(int id)
        {
            var empleado = gestor.ObtenerPorId(id);

            if (empleado == null)
                return NotFound();

            return View(empleado);
        }

        // POST: Empleados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Empleado empleado)
        {
            if (id != empleado.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(empleado);

            gestor.ActualizarEmpleado(empleado);
            return RedirectToAction(nameof(Index));
        }

        // POST: Empleados/ToggleActivo/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleActivo(int id)
        {
            gestor.ToggleActivo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
