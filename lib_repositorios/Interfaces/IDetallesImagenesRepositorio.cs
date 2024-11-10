// Librerias
using lib_entidades.Modelos;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Interfaces
{
    // Firma de los metodos
    public interface IDetallesImagenesRepositorio
    {
        void Configurar(string string_conexion);

        List<DetallesImagenes> Listar();

        List<DetallesImagenes> Buscar(Expression<Func<DetallesImagenes, bool>> condiciones);

        DetallesImagenes Guardar(DetallesImagenes entidad);

        DetallesImagenes Modificar(DetallesImagenes entidad);

        DetallesImagenes Borrar(DetallesImagenes entidad);

        bool Existe(Expression<Func<DetallesImagenes, bool>> condiciones);
    }
}
