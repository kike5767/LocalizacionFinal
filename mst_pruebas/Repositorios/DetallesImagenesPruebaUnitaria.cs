// Librerias
using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

// Proyecto
namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class DetallesImagenesPruebaUnitaria
    {
        private IDetallesImagenesRepositorio? iRepositorio = null;
        private DetallesImagenes? entidad = null;
        //Constructor
        public DetallesImagenesPruebaUnitaria()
        {
            var conexion = new Conexion();
            //conexion.StringConnection = "server=localhost;database=db_facturas;Integrated \r\nSecurity=True;TrustServerCertificate=true;";
            conexion.StringConnection = "Server=CARZAXO\\DEV;Database=db_Localizacion;Integrated Security=True;TrustServerCertificate=True;";
            iRepositorio = new DetallesImagenesRepositorio(conexion);
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
            entidad = new DetallesImagenes()
            {
                Autor = "ITM",
                Titulo = "SEDE FRATERNIDAD",
                Fecha = DateTime.Now,
                Detalles = "Campus Universitario",
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
            entidad!.Autor = "Luis";
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