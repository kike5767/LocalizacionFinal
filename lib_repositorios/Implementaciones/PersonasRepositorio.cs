// Librerias
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Implementaciones
{
    public class PersonasRepositorio : IPersonasRepositorio
    {
        // Variable de tipo conexion para interactuar con la DB
        private Conexion? conexion;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;
        // Constructor
        public PersonasRepositorio(Conexion conexion, IAuditoriaRepositorio? iAuditoriaRepositorio)
        {
            this.conexion = conexion;
            this.iAuditoriaRepositorio = iAuditoriaRepositorio;
        }
        // Metodos definidos por la interfaz y llamado a metodos de la clase Conexion
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        // Obtener todas las entidades
        public List<Personas> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Personas",
                Id = 1
            });
            return conexion!.Listar<Personas>();
        }
        // Buscar entidades bajo determinadas condiciones
        public List<Personas> Buscar(Expression<Func<Personas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        // Guardar una nueva entidad
        public Personas Guardar(Personas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Modificar una entidad ya existente
        public Personas Modificar(Personas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Borrar una entidad ya existente
        public Personas Borrar(Personas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Verificar la existencia de una entidad que cumple ciertas condiciones y devuelve un valor booleano
        public bool Existe(Expression<Func<Personas, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}