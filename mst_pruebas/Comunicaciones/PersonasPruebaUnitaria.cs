using lib_comunicaciones.Implementaciones; // Implementaciones de las interfaces de comunicación
using lib_comunicaciones.Interfaces; // Definición de interfaces
using lib_entidades.Modelos; // Modelos de datos
using lib_utilidades; // Utilidades para conversión JSON

namespace mst_pruebas.Comunicaciones
{
    [TestClass] // Indica que esta clase contiene pruebas unitarias
    public class UsuarioAutenticacion
    {
        private IUsuarioComunicacion? iComunicacion = null; // Interfaz para manejo de usuarios
        private Usuario? usuario = null; // Usuario de prueba
        private Dictionary<string, object>? resultado = null; // Almacena resultados de pruebas

        // Constructor para inicializar la comunicación con `UsuarioComunicacion`
        public UsuarioAutenticacion()
        {
            iComunicacion = new UsuarioComunicacion();
        }

        [TestMethod] // Método principal que ejecuta todas las pruebas
        public void Ejecutar()
        {
            Registro();     // Prueba para el registro de usuarios
            Login();        // Prueba para la autenticación
            Actualizar();   // Prueba para actualización de datos
            Eliminar();     // Prueba para eliminar el usuario
        }

        private void Registro()
        {
            var datos = new Dictionary<string, object>();
            usuario = new Usuario()
            {
                NombreUsuario = "usuario_prueba", // Nombre de usuario de prueba
                Contrasena = "123456",           // Contraseña de prueba
                Email = "correo@prueba.com",     // Email de prueba
                Activo = true
            };
            datos["Entidad"] = usuario!;

            // Ejecuta la operación de registro
            var task = iComunicacion!.Registrar(datos);
            task.Wait();
            resultado = task.Result;

            Assert.IsTrue(!resultado!.ContainsKey("Error")); // Verifica que no haya errores

            usuario = JsonConversor.ConvertirAObjeto<Usuario>(
                JsonConversor.ConvertirAString(resultado["Entidad"]));
        }

        private void Login()
        {
            var datos = new Dictionary<string, object>
            {
                ["Usuario"] = usuario!.NombreUsuario,
                ["Contrasena"] = usuario!.Contrasena
            };

            // Ejecuta la operación de autenticación
            var task = iComunicacion!.Autenticar(datos);
            task.Wait();
            resultado = task.Result;

            Assert.IsTrue(!resultado!.ContainsKey("Error")); // Verifica que no haya errores
        }

        private void Actualizar()
        {
            var datos = new Dictionary<string, object>();
            usuario!.Email = "nuevo_correo@prueba.com"; // Cambia el correo electrónico
            datos["Entidad"] = usuario!;

            // Ejecuta la operación de actualización
            var task = iComunicacion!.Actualizar(datos);
            task.Wait();
            resultado = task.Result;

            Assert.IsTrue(!resultado!.ContainsKey("Error")); // Verifica que no haya errores

            usuario = JsonConversor.ConvertirAObjeto<Usuario>(
                JsonConversor.ConvertirAString(resultado["Entidad"]));
        }

        private void Eliminar()
        {
            var datos = new Dictionary<string, object>
            {
                ["Entidad"] = usuario! // Define la entidad a eliminar
            };

            // Ejecuta la operación de eliminación
            var task = iComunicacion!.Eliminar(datos);
            task.Wait();
            resultado = task.Result;

            Assert.IsTrue(!resultado!.ContainsKey("Error")); // Verifica que no haya errores
        }
    }
}
