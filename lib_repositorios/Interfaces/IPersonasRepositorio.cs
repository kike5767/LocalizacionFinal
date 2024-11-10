// Librerias
using lib_entidades.Modelos;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Interfaces
{
    // Firma de los metodos
    public interface IPersonasRepositorio
    {
        void Configurar(string string_conexion);

        List<Personas> Listar();

        List<Personas> Buscar(Expression<Func<Personas, bool>> condiciones);

        Personas Guardar(Personas entidad);

        Personas Modificar(Personas entidad);

        Personas Borrar(Personas entidad);

        bool Existe(Expression<Func<Personas, bool>> condiciones);
    }
}
