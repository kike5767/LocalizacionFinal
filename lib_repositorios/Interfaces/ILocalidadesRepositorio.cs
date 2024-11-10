// Librerias
using lib_entidades.Modelos;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Interfaces
{
    // Firma de los metodos
    public interface ILocalidadesRepositorio
    {
        void Configurar(string string_conexion);

        List<Localidades> Listar();

        List<Localidades> Buscar(Expression<Func<Localidades, bool>> condiciones);

        Localidades Guardar(Localidades entidad);

        Localidades Modificar(Localidades entidad);

        Localidades Borrar(Localidades entidad);

        bool Existe(Expression<Func<Localidades, bool>> condiciones);
    }
}
