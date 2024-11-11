// Librerias
using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_aplicaciones.Implementaciones
{
    public class LocalidadesAplicacion : ILocalidadesAplicacion
    {
        // Variable para interactuar con el repositorio
        private ILocalidadesRepositorio? iRepositorio = null;
        // Constructor
        public LocalidadesAplicacion(ILocalidadesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        // Metodos
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Localidades Borrar(Localidades entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Localidades Guardar(Localidades entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Localidades> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Localidades> Buscar(Localidades entidad, string tipo)
        {
            Expression<Func<Localidades, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Pais!.Contains(entidad.Pais!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Localidades Modificar(Localidades entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
        /* Metodo vacio
        private Localidades Calcular(Localidades entidad)
        {
        }
        */
    }
}