// Librerias
using lib_entidades.Modelos;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Interfaces
{
    // Firma de los metodos
    public interface ILocalizacionesRepositorio
    {
        void Configurar(string string_conexion);

        List<Localizaciones> Listar();

        List<Localizaciones> Buscar(Expression<Func<Localizaciones, bool>> condiciones);

        Localizaciones Guardar(Localizaciones entidad);

        Localizaciones Modificar(Localizaciones entidad);

        Localizaciones Borrar(Localizaciones entidad);

        bool Existe(Expression<Func<Localizaciones, bool>> condiciones);
    }
}
