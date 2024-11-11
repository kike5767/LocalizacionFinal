// Librerias
using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_aplicaciones.Implementaciones
{
    public class DetallesImagenesAplicacion : IDetallesImagenesAplicacion
    {
        // Variable para interactuar con el repositorio
        private IDetallesImagenesRepositorio? iRepositorio = null;
        // Constructor
        public DetallesImagenesAplicacion(IDetallesImagenesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        // Metodos
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public DetallesImagenes Borrar(DetallesImagenes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public DetallesImagenes Guardar(DetallesImagenes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<DetallesImagenes> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<DetallesImagenes> Buscar(DetallesImagenes entidad, string tipo)
        {
            Expression<Func<DetallesImagenes, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Autor!.Contains(entidad.Autor!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public DetallesImagenes Modificar(DetallesImagenes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
        /* Metodo vacio
        private DetallesImagenes Calcular(DetallesImagenes entidad)
        {
        }
        */
    }
}