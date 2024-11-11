using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class LocalidadesPruebaUnitaria
    {
        private ILocalidadesComunicacion? iComunicacion = null;
        private Localidades? entidad = null;
        private List<Localidades>? lista = null;

        public LocalidadesPruebaUnitaria()
        {
            iComunicacion = new LocalidadesComunicacion();
        }

        [TestMethod]
        public void Executar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();
        }

        private void Listar()
        {
            var datos = new Dictionary<string, object>();
            var task = iComunicacion!.Listar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            lista = JsonConversor.ConvertirAObjeto<List<Localidades>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;
            datos["Tipo"] = "NOMBRE";

            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            lista = JsonConversor.ConvertirAObjeto<List<Localidades>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new Localidades()
            {
                Pais = "Colombia",
                Estado = "None",
                CodigoPostal = "05001",
                Ciudad = "Medellín",
                Barrio = "San Diego",
                Calle = "32",
            };
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<Localidades>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Pais = "España";
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<Localidades>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Borrar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Borrar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<Localidades>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}