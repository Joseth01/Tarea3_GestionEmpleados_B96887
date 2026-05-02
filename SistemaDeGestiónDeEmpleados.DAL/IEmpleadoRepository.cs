using SistemaDeGestiónDeEmpleados.MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestiónDeEmpleados.DAL
{
    public interface IEmpleadoRepository
    {
        IEnumerable<Empleado> ObtenerTodos();
        Empleado ObtenerPorId(int id);

        IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino);

        IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda);

        int ContarTotal(string busqueda);

        void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
    }
}
