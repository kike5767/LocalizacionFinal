// Librerias
using lib_entidades.Modelos;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Interfaces
{
    // Firma de los metodos
    public interface IImagenesRepositorio
    {
        void Configurar(string string_conexion);

        List<Imagenes> Listar();

        List<Imagenes> Buscar(Expression<Func<Imagenes, bool>> condiciones);

        Imagenes Guardar(Imagenes entidad);

        Imagenes Modificar(Imagenes entidad);

        Imagenes Borrar(Imagenes entidad);

        bool Existe(Expression<Func<Imagenes, bool>> condiciones);
    }
}
