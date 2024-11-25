// Librerias
using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_repositorios.Implementaciones
{
    public class ImagenesRepositorio : IImagenesRepositorio
    {
        // Variable de tipo conexion para interactuar con la DB
        private Conexion? conexion;
        private IAuditoriaRepositorio? iAuditoriaRepositorio;
        // Constructor
        public ImagenesRepositorio(Conexion conexion, IAuditoriaRepositorio? iAuditoriaRepositorio)
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
        public List<Imagenes> Listar()
        {
            iAuditoriaRepositorio!.Guardar(new Auditoria()
            {
                Tabla = "Imagenes",
                Id = 1
            });
            return conexion!.Listar<Imagenes>();
        }
        // Buscar entidades bajo determinadas condiciones
        public List<Imagenes> Buscar(Expression<Func<Imagenes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }
        // Guardar una nueva entidad
        public Imagenes Guardar(Imagenes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Modificar una entidad ya existente
        public Imagenes Modificar(Imagenes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Borrar una entidad ya existente
        public Imagenes Borrar(Imagenes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            conexion!.Separar(entidad);
            return entidad;
        }
        // Verificar la existencia de una entidad que cumple ciertas condiciones y devuelve un valor booleano
        public bool Existe(Expression<Func<Imagenes, bool>> condiciones)
        {
            return conexion!.Existe(condiciones);
        }
    }
}