using SistemaDeGestiónDeEmpleados.DAL;
using SistemaDeGestiónDeEmpleados.MODEL;

namespace SistemaDeGestiónDeEmpleados.BL
{
    public class GestorDeEmpleados
    {
        private readonly IEmpleadoRepository repositorio;

        public GestorDeEmpleados(IEmpleadoRepository repositorio)
        {
            this.repositorio = repositorio;
        }

        public IEnumerable<Empleado> ObtenerEmpleados(int pagina, int tamano, string busqueda)
        {
            return repositorio.ObtenerPaginado(pagina, tamano, busqueda);
        }

        public int ObtenerTotalRegistros(string busqueda)
        {
            return repositorio.ContarTotal(busqueda);
        }

        public Empleado ObtenerPorId(int id)
        {
            return repositorio.ObtenerPorId(id);
        }

        public void CrearEmpleado(Empleado empleado)
        {
            empleado.FechaIngreso = DateTime.Now;
            empleado.Activo = true;

            repositorio.Agregar(empleado);
        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            repositorio.Actualizar(empleado);
        }

        public void ToggleActivo(int id)
        {
            var empleado = repositorio.ObtenerPorId(id);

            if (empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                repositorio.Actualizar(empleado);
            }
        }
    }
}
