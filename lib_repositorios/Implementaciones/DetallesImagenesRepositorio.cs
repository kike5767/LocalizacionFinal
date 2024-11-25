// Librerias
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Implementaciones
{
    public class DetallesImagenesRepositorio : IDetallesImagenesRepositorio
    {
        // Variable de tipo conexion para interactuar con la DB
        private Conexion? conexion;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;
        // Constructor
        public DetallesImagenesRepositorio(Conexion conexion, IAuditoriaRepositorio iAuditoriaRepositorio)
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
        public List<DetallesImagenes> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "DetallesImagenes",
                Id = 1
            });
            return conexion!.Listar<DetallesImagenes>();
        }
        // Buscar entidades bajo determinadas condiciones
        public List<DetallesImagenes> Buscar(Expression<Func<DetallesImagenes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        // Guardar una nueva entidad
        public DetallesImagenes Guardar(DetallesImagenes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Modificar una entidad ya existente
        public DetallesImagenes Modificar(DetallesImagenes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Borrar una entidad ya existente
        public DetallesImagenes Borrar(DetallesImagenes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Verificar la existencia de una entidad que cumple ciertas condiciones y devuelve un valor booleano
        public bool Existe(Expression<Func<DetallesImagenes, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}