// Librerias
using System.ComponentModel.DataAnnotations;

// Proyecto
namespace lib_entidades.Modelos
{
    // Clase que representa la informacion de la personas registradas en el sistema
    public class Personas
    {
        // Atributos y propiedades
        [Key] public int Id { get; set; }
        public string? Cedula { get; set; } 
        public string? Nombre { get; set; } 
        public int Edad { get; set; }
        public bool Activo { get; set; }

        // Metodos
    }
}
