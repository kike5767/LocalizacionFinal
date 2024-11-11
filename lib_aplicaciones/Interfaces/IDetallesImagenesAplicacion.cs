// Librerias
using lib_entidades.Modelos;

// Proyecto
namespace lib_aplicaciones.Interfaces
{
    // Firma de los metodos
    public interface IDetallesImagenesAplicacion
    {
        void Configurar(string string_conexion);

        List<DetallesImagenes> Listar();

        List<DetallesImagenes> Buscar(DetallesImagenes entidad, string tipo);

        DetallesImagenes Guardar(DetallesImagenes entidad);

        DetallesImagenes Modificar(DetallesImagenes entidad);

        DetallesImagenes Borrar(DetallesImagenes entidad);
    }
}