using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_utilidades;

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class LocalizacionesPruebaUnitaria
    {
        private ILocalizacionesComunicacion? iComunicacion = null;
        private Localizaciones? entidad = null;
        private List<Localizaciones>? lista = null;

        public LocalizacionesPruebaUnitaria()
        {
            iComunicacion = new LocalizacionesComunicacion();
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

            lista = JsonConversor.ConvertirAObjeto<List<Localizaciones>>(
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

            lista = JsonConversor.ConvertirAObjeto<List<Localizaciones>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
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
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<Localizaciones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.personas = 1;
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<Localizaciones>(
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

            entidad = JsonConversor.ConvertirAObjeto<Localizaciones>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}