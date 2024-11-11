// Librerias
using lib_entidades.Modelos;

// Proyecto
namespace lib_aplicaciones.Interfaces
{
    // Firma de los metodos
    public interface ILocalizacionesAplicacion
    {
        void Configurar(string string_conexion);

        List<Localizaciones> Listar();

        List<Localizaciones> Buscar(Localizaciones entidad, string tipo);

        Localizaciones Guardar(Localizaciones entidad);

        Localizaciones Modificar(Localizaciones entidad);

        Localizaciones Borrar(Localizaciones entidad);
    }
}