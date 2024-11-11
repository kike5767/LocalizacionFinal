// Librerias
using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_aplicaciones.Implementaciones
{
    public class ImagenesAplicacion : IImagenesAplicacion
    {
        // Variable para interactuar con el repositorio
        private IImagenesRepositorio? iRepositorio = null;
        // Constructor
        public ImagenesAplicacion(IImagenesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        // Metodos
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Imagenes Borrar(Imagenes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Imagenes Guardar(Imagenes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Imagenes> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Imagenes> Buscar(Imagenes entidad, string tipo)
        {
            Expression<Func<Imagenes, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Url!.Contains(entidad.Url!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Imagenes Modificar(Imagenes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
        /* Metodo vacio
        private Imagenes Calcular(Imagenes entidad)
        {
        }
        */
    }
  
}
