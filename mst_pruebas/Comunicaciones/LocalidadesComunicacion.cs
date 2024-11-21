using lib_comunicaciones.Implementaciones; // Implementaciones de las interfaces de comunicación
using lib_comunicaciones.Interfaces; // Definición de las interfaces
using lib_entidades.Modelos; // Modelos de datos
using lib_utilidades; // Utilidades para conversión JSON

namespace mst_pruebas.Comunicaciones
{
    [TestClass] // Indica que esta clase contiene pruebas unitarias
    public class VideosPruebaUnitaria
    {
        private IVideosComunicacion? iComunicacion = null; // Interfaz para la comunicación
        private Videos? entidad = null; // Entidad de prueba
        private List<Videos>? lista = null; // Lista para almacenar resultados

        // Constructor para inicializar la comunicación con `VideosComunicacion`
        public VideosPruebaUnitaria()
        {
            iComunicacion = new VideosComunicacion();
        }

        [TestMethod] // Método principal para ejecutar todas las pruebas
        public void Executar()
        {
            Guardar();  // Prueba para guardar una entidad
            Listar();   // Prueba para listar entidades
            Buscar();   // Prueba para buscar una entidad específica
            Modificar(); // Prueba para modificar una entidad
            Borrar();   // Prueba para eliminar una entidad
        }

        private void Listar()
        {
            // Diccionario de datos para la operación
            var datos = new Dictionary<string, object>();

            // Ejecuta la tarea de listar entidades
            var task = iComunicacion!.Listar(datos);
            task.Wait();
            datos = task.Result;

            // Verifica que no haya errores en la respuesta
            Assert.IsTrue(!datos.ContainsKey("Error"));

            // Convierte el resultado a una lista de entidades `Videos`
            lista = JsonConversor.ConvertirAObjeto<List<Videos>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        private void Buscar()
        {
            // Diccionario para enviar datos de búsqueda
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = entidad!, // Se busca con la entidad definida
                ["Tipo"] = "NOMBRE" // Tipo de búsqueda
            };

            // Ejecuta la tarea de búsqueda
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            datos = task.Result;

            // Asegura que no haya errores en la búsqueda
            Assert.IsTrue(!datos.ContainsKey("Error"));

            // Convierte el resultado en una lista de entidades `Videos`
            lista = JsonConversor.ConvertirAObjeto<List<Videos>>(
                JsonConversor.ConvertirAString(datos["Entidades"]));
        }

        public void Guardar()
        {
            // Diccionario para enviar datos de guardado
            var datos = new Dictionary<string, object>();
            entidad = new Videos()
            {
                Url = "Video Test 1", // URL de prueba
                Titulo = "Título de Prueba"
            };
            datos["Entidad"] = entidad!;

            // Ejecuta la tarea de guardar la entidad
            var task = iComunicacion!.Guardar(datos);
            task.Wait();
            datos = task.Result;

            // Verifica que no haya errores
            Assert.IsTrue(!datos.ContainsKey("Error"));

            // Convierte el resultado en una instancia de `Videos`
            entidad = JsonConversor.ConvertirAObjeto<Videos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Modificar()
        {
            // Diccionario para enviar datos de modificación
            var datos = new Dictionary<string, object>();
            entidad!.Titulo = "Nuevo Título"; // Actualiza el título
            datos["Entidad"] = entidad!;

            // Ejecuta la tarea de modificar la entidad
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            datos = task.Result;

            // Verifica que no haya errores
            Assert.IsTrue(!datos.ContainsKey("Error"));

            // Convierte el resultado en una instancia de `Videos` actualizada
            entidad = JsonConversor.ConvertirAObjeto<Videos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }

        public void Borrar()
        {
            // Diccionario para enviar datos de borrado
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = entidad! // Entidad a eliminar
            };

            // Ejecuta la tarea de borrar la entidad
            var task = iComunicacion!.Borrar(datos);
            task.Wait();
            datos = task.Result;

            // Verifica que no haya errores
            Assert.IsTrue(!datos.ContainsKey("Error"));

            // Convierte el resultado en una instancia de `Videos`
            entidad = JsonConversor.ConvertirAObjeto<Videos>(
                JsonConversor.ConvertirAString(datos["Entidad"]));
        }
    }
}