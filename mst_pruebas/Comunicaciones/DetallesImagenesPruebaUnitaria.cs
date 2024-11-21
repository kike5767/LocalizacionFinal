using lib_comunicaciones.Implementaciones; // Referencia a la implementación concreta de las interfaces de comunicación.
using lib_comunicaciones.Interfaces; // Referencia a las interfaces que definen la comunicación.
using lib_entidades.Modelos; // Modelos de datos utilizados en la prueba.
using lib_utilidades; // Utilidades para conversión y manejo de datos.

namespace mst_pruebas.Comunicaciones
{
    [TestClass]
    public class DetallesImagenesPruebaUnitaria
    {
        private IDetallesImagenesComunicacion? iComunicacion = null; // Instancia de comunicación para manejar la lógica de negocio.
        private DetallesImagenes? entidad = null; // Entidad individual para pruebas.
        private List<DetallesImagenes>? lista = null; // Lista de entidades para pruebas.

        public DetallesImagenesPruebaUnitaria()
        {
            iComunicacion = new DetallesImagenesComunicacion(); // Inicialización de la implementación.
        }

        [TestMethod]
        public void Executar()
        {
            Guardar(); // Prueba para guardar una entidad.
            Listar(); // Prueba para listar entidades.
            Buscar(); // Prueba para buscar entidades específicas.
            Modificar(); // Prueba para modificar una entidad.
            Borrar(); // Prueba para eliminar una entidad.
        }

        private void Listar()
        {
            var datos = new Dictionary<string, object>(); // Diccionario para parámetros de entrada.
            var task = iComunicacion!.Listar(datos); // Llamada al método asíncrono Listar.
            task.Wait(); // Espera a que la tarea termine.
            datos = task.Result; // Resultado del método Listar.
            Assert.IsTrue(!datos.ContainsKey("Error")); // Validación para asegurar que no haya errores.

            lista = JsonConversor.ConvertirAObjeto<List<DetallesImagenes>>(
                JsonConversor.ConvertirAString(datos["Entidades"])); // Conversión del resultado a lista de entidades.
        }

        private void Buscar()
        {
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!; // Asignación de la entidad a buscar.
            datos["Tipo"] = "NOMBRE"; // Especificación del criterio de búsqueda.

            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            lista = JsonConversor.ConvertirAObjeto<List<DetallesImagenes>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        public void Guardar()
        {
            var datos = new Dictionary<string, object>();
            entidad = new DetallesImagenes()
            {
                Autor = "ITM",
                Titulo = "SEDE FRATERNIDAD",
                Fecha = DateTime.Now,
                Detalles = "Campus Universitario",
                Activo = true,
            };
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<DetallesImagenes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Modificar()
        {
            var datos = new Dictionary<string, object>();
            entidad!.Autor = "szs";
            datos["Entidad"] = entidad!;

            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;
            Assert.IsTrue(!datos.ContainsKey("Error"));

            entidad = JsonConversor.ConvertirAObjeto<DetallesImagenes>(
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

            entidad = JsonConversor.ConvertirAObjeto<DetallesImagenes>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}