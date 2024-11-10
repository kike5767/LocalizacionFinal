// Librerias
using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

// Proyecto
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class UbicacionesPruebaUnitaria
    {
        private IUbicacionesRepositorio? iRepositorio = null;
        private Ubicaciones? entidad = null;
        // Constructor
        public UbicacionesPruebaUnitaria()
        {
            var conexion = new Conexion();
            //conexion.StringConnection = "server=localhost;database=db_facturas;Integrated \r\nSecurity=True;TrustServerCertificate=true;";
            conexion.StringConnection = "Server=CARZAXO\\DEV;Database=db_Localizacion;Integrated Security=True;TrustServerCertificate=True;";
         
            iRepositorio = new UbicacionesRepositorio(conexion);
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
            entidad = new Ubicaciones()
            {
                Latitud = 6.244922241492459M,
                Longitud = -75.55001051413606M,
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
            entidad!.Latitud = 4.244922241492459M;
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