using SistemaDeGestiónDeEmpleados.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestiónDeEmpleados.DAL
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext contexto;

        public EmpleadoRepository(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public IEnumerable<Empleado> ObtenerTodos()
        {
            return contexto.Empleados.ToList();
        }

        public Empleado ObtenerPorId(int id)
        {
            return contexto.Empleados.Find(id);
        }

        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            termino = termino?.ToLower() ?? "";

            return contexto.Empleados
                .Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino))
                .ToList();
        }

        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda)
        {
            var consulta = contexto.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();

                consulta = consulta.Where(e =>
                    e.Nombre.ToLower().Contains(busqueda) ||
                    e.Apellidos.ToLower().Contains(busqueda) ||
                    e.Departamento.ToLower().Contains(busqueda));
            }

            return consulta
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string busqueda)
        {
            var consulta = contexto.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();

                consulta = consulta.Where(e =>
                    e.Nombre.ToLower().Contains(busqueda) ||
                    e.Apellidos.ToLower().Contains(busqueda) ||
                    e.Departamento.ToLower().Contains(busqueda));
            }

            return consulta.Count();
        }

        public void Agregar(Empleado empleado)
        {
            contexto.Empleados.Add(empleado);
            contexto.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            contexto.Empleados.Update(empleado);
            contexto.SaveChanges();
        }
    }
}
