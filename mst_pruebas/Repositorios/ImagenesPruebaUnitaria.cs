// Librerias
using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

// Proyecto
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class ImagenesPruebaUnitaria
    {
        private IImagenesRepositorio? iRepositorio = null;
        private Imagenes? entidad = null;
        // Constructor
        public ImagenesPruebaUnitaria()
        {
            var conexion = new Conexion();
            //conexion.StringConnection = "server=localhost;database=db_facturas;Integrated \r\nSecurity=True;TrustServerCertificate=true;"
            conexion.StringConnection = "Server=CARZAXO\\DEV;Database=db_Localizacion;Integrated Security=True;TrustServerCertificate=True;";
                
            iRepositorio = new ImagenesRepositorio(conexion);
        }
        // Metodos de prueba
        [TestMethod]
        public void Ejecutar()
        {
            Listar();
            Guardar();
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }

        private void Guardar()
        {
            entidad = new Imagenes()
            {
                Url = "Test 1",
            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }
    }
}