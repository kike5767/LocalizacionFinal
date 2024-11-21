using lib_comunicaciones.Implementaciones; // Implementaciones de interfaces
using lib_comunicaciones.Interfaces; // Definición de interfaces
using lib_entidades.Modelos; // Modelos de datos
using lib_utilidades; // Utilidades de conversión JSON

namespace mst_pruebas.Comunicaciones
{
    [TestClass] // Indica que esta clase contiene pruebas unitarias
    public class RolesGestion
    {
        private IRolesComunicacion? iComunicacion = null; // Interfaz para gestionar roles
        private Rol? rol = null; // Instancia de prueba
        private List<Rol>? lista = null; // Lista para almacenar resultados

        // Constructor para inicializar la comunicación
        public RolesGestion()
        {
            iComunicacion = new RolesComunicacion();
        }

        [TestMethod] // Método principal que ejecuta todas las pruebas
        public void Ejecutar()
        {
            Crear();     // Prueba para crear un rol
            Listar();    // Prueba para listar roles
            Buscar();    // Prueba para buscar un rol
            Modificar(); // Prueba para modificar un rol
            Eliminar();  // Prueba para eliminar un rol
        }

        private void Crear()
        {
            var datos = new Dictionary<string, object>();
            rol = new Rol()
            {
                Nombre = "Administrador", // Nombre del rol
                Descripcion = "Rol con todos los permisos"
            };
            datos["Entidad"] = rol!;

            // Ejecuta la operación de creación
            var task = iComunicacion!.Crear(datos);
            task.Wait();
            var resultado = task.Result;

            Assert.IsTrue(!resultado.ContainsKey("Error")); // Verifica que no haya errores

            rol = JsonConversor.ConvertirAObjeto<Rol>(
                JsonConversor.ConvertirAString(resultado["Entidad"]));
        }

        private void Listar()
        {
            var datos = new Dictionary<string, object>();

            // Ejecuta la operación de listar roles
            var task = iComunicacion!.Listar(datos);
            task.Wait();
            var resultado = task.Result;

            Assert.IsTrue(!resultado.ContainsKey("Error")); // Verifica que no haya errores

            lista = JsonConversor.ConvertirAObjeto<List<Rol>>(
                JsonConversor.ConvertirAString(resultado["Entidades"]));
        }

        private void Buscar()
        {
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = rol!, // Busca con la instancia de prueba
                ["Tipo"] = "NOMBRE" // Tipo de búsqueda
            };

            // Ejecuta la operación de búsqueda
            var task = iComunicacion!.Buscar(datos);
            task.Wait();
            var resultado = task.Result;

            Assert.IsTrue(!resultado.ContainsKey("Error")); // Verifica que no haya errores

            lista = JsonConversor.ConvertirAObjeto<List<Rol>>(
                JsonConversor.ConvertirAString(resultado["Entidades"]));
        }

        private void Modificar()
        {
            var datos = new Dictionary<string, object>();
            rol!.Descripcion = "Descripción actualizada"; // Cambia la descripción
            datos["Entidad"] = rol!;

            // Ejecuta la operación de modificación
            var task = iComunicacion!.Modificar(datos);
            task.Wait();
            var resultado = task.Result;

            Assert.IsTrue(!resultado.ContainsKey("Error")); // Verifica que no haya errores

            rol = JsonConversor.ConvertirAObjeto<Rol>(
                JsonConversor.ConvertirAString(resultado["Entidad"]));
        }

        private void Eliminar()
        {
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = rol! // Define el rol a eliminar
            };

            // Ejecuta la operación de eliminación
            var task = iComunicacion!.Eliminar(datos);
            task.Wait();
            var resultado = task.Result;

            Assert.IsTrue(!resultado.ContainsKey("Error")); // Verifica que no haya errores
        }
    }
}