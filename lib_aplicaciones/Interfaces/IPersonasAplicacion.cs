// Librerias
using lib_entidades.Modelos;

// Proyecto
namespace lib_aplicaciones.Interfaces
{
    // Firma de los metodos
    public interface IPersonasAplicacion
    {
        void Configurar(string string_conexion);

        List<Personas> Listar();

        List<Personas> Buscar(Personas entidad, string tipo);

        Personas Guardar(Personas entidad);

        Personas Modificar(Personas entidad);

        Personas Borrar(Personas entidad);
    }
}
