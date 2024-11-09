// Librerias
using System.ComponentModel.DataAnnotations;

// Proyecto
namespace lib_entidades.Modelos
{
    // Esta clase estara asociada a una localizacion y proyectara una imagen a traves de su url en la web
    public class Imagenes
    {
        // Atributos y propiedades
        [Key] public int Id { get; set; }
        public string? Url { get; set; } 

        // Metodos
    }
}
