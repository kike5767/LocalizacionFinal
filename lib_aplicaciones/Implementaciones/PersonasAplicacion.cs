// Librerias
using lib_entidades.Modelos;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

// Proyecto
namespace lib_aplicaciones.Implementaciones
{
    public class PersonasAplicacion : IPersonasAplicacion
    {
        // Variable para interactuar con el repositorio
        private IPersonasRepositorio? iRepositorio = null;
        // Constructor
        public PersonasAplicacion(IPersonasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }
        // Metodos
        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Personas Borrar(Personas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Personas Guardar(Personas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Personas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Personas> Buscar(Personas entidad, string tipo)
        {
            Expression<Func<Personas, bool>>? condiciones = null;
            switch (tipo.ToUpper())
            {
                case "NOMBRE": condiciones = x => x.Cedula!.Contains(entidad.Cedula!); break;
                default: condiciones = x => x.Id == entidad.Id; break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }

        public Personas Modificar(Personas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
        /* Metodo vacio
        private Personas Calcular(Personas entidad)
        {
        }
        */
    }
}