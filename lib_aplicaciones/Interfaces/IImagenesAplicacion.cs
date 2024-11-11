// Librerias
using lib_entidades.Modelos;

// Proyecto
namespace lib_aplicaciones.Interfaces
{
    // Firma de los metodos
    public interface IImagenesAplicacion
    {
        void Configurar(string string_conexion);

        List<Imagenes> Listar();

        List<Imagenes> Buscar(Imagenes entidad, string tipo);

        Imagenes Guardar(Imagenes entidad);

        Imagenes Modificar(Imagenes entidad);

        Imagenes Borrar(Imagenes entidad);
    }
}