// Librerias
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Implementaciones
{
    public class LocalizacionesRepositorio : ILocalizacionesRepositorio
    {
        // Variable de tipo conexion para interactuar con la DB
        private Conexion? conexion;
        // Constructor
        public LocalizacionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }
        // Metodos definidos por la interfaz y llamado a metodos de la clase Conexion
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        // Obtener todas las entidades
        public List<Localizaciones> Listar()
        {
            return conexion!.Listar<Localizaciones>();
        }
        // Buscar entidades bajo determinadas condiciones
        public List<Localizaciones> Buscar(Expression<Func<Localizaciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        // Guardar una nueva entidad
        public Localizaciones Guardar(Localizaciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Modificar una entidad ya existente
        public Localizaciones Modificar(Localizaciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Borrar una entidad ya existente
        public Localizaciones Borrar(Localizaciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Verificar la existencia de una entidad que cumple ciertas condiciones y devuelve un valor booleano
        public bool Existe(Expression<Func<Localizaciones, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}