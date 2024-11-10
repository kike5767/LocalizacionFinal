// Librerias
using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

// Proyecto
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class LocalizacionesPruebaUnitaria
    {
        private ILocalizacionesRepositorio? iRepositorio = null;
        private Localizaciones? entidad = null;
        // Constructor
        public LocalizacionesPruebaUnitaria()
        {
            var conexion = new Conexion();
            //conexion.StringConnection = "server=CARZAXO;database=db_Localizacion;Integrated \r\nSecurity=True;TrustServerCertificate=true;";
            conexion.StringConnection = "Server=CARZAXO\\DEV;Database=db_Localizacion;Integrated Security=True;TrustServerCertificate=True;";
           
            iRepositorio = new LocalizacionesRepositorio(conexion);
        }
        // Metodos de prueba
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Guardar()
        {
            entidad = new Localizaciones()
            {
                personas = 1,
                localidades = 1,
                ubicaciones = 1,
                imagenes = 1,
                detalles = 1,
                Hora = DateTime.Now.TimeOfDay,
                Activo = true,
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        public void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id ==
           entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar()
        {
            entidad!.personas = 2;
            entidad = iRepositorio!.Modificar(entidad!);
            var lista = iRepositorio!.Buscar(x => x.Id ==
           entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);
            var lista = iRepositorio!.Buscar(x => x.Id ==
           entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }
    }
}