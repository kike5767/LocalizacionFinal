// Librerias
using lib_entidades.Modelos;

// Proyecto
namespace lib_aplicaciones.Interfaces
{
    // Firma de los metodos
    public interface ILocalidadesAplicacion
    {
        void Configurar(string string_conexion);

        List<Localidades> Listar();

        List<Localidades> Buscar(Localidades entidad, string tipo);

        Localidades Guardar(Localidades entidad);

        Localidades Modificar(Localidades entidad);

        Localidades Borrar(Localidades entidad);
    }
}