// Librerias
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Implementaciones
{
    public class LocalidadesRepositorio : ILocalidadesRepositorio
    {
        // Variable de tipo conexion para interactuar con la DB
        private Conexion? conexion;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;
        // Constructor
        public LocalidadesRepositorio(Conexion conexion, IAuditoriaRepositorio? iAuditoriaRepositorio)
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
        public List<Localidades> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Localidades",
                Id = 1
            });
            return conexion!.Listar<Localidades>();
        }
        // Buscar entidades bajo determinadas condiciones
        public List<Localidades> Buscar(Expression<Func<Localidades, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        // Guardar una nueva entidad
        public Localidades Guardar(Localidades entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Modificar una entidad ya existente
        public Localidades Modificar(Localidades entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Borrar una entidad ya existente
        public Localidades Borrar(Localidades entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Verificar la existencia de una entidad que cumple ciertas condiciones y devuelve un valor booleano
        public bool Existe(Expression<Func<Localidades, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}