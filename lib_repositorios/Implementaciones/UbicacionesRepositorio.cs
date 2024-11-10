// Librerias
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Implementaciones
{
    public class UbicacionesRepositorio : IUbicacionesRepositorio
    {
        // Variable de tipo conexion para interactuar con la DB
        private Conexion? conexion;
        // Constructor
        public UbicacionesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }
        // Metodos definidos por la interfaz y llamado a metodos de la clase Conexion
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        // Obtener todas las entidades
        public List<Ubicaciones> Listar()
        {
            return conexion!.Listar<Ubicaciones>();
        }
        // Buscar entidades bajo determinadas condiciones
        public List<Ubicaciones> Buscar(Expression<Func<Ubicaciones, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        // Guardar una nueva entidad
        public Ubicaciones Guardar(Ubicaciones entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Modificar una entidad ya existente
        public Ubicaciones Modificar(Ubicaciones entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Borrar una entidad ya existente
        public Ubicaciones Borrar(Ubicaciones entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Verificar la existencia de una entidad que cumple ciertas condiciones y devuelve un valor booleano
        public bool Existe(Expression<Func<Ubicaciones, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}