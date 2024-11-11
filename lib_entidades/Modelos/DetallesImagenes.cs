// Librerias
using System.ComponentModel.DataAnnotations;

// Proyecto
namespace lib_entidades.Modelos
{
    // Clase que proporcionara los detalles de la clase imagen y respetara los derechos de autor
    public class DetallesImagenes
    {
        // Atributos y propiedades
        [Key] public int Id { get; set; }
        public string? Autor { get; set; } 
        public string? Titulo { get; set; } 
        public DateTime Fecha { get; set; }
        public string? Detalles { get; set; } 
        public bool Activo { get; set; }

        // Metodos
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Autor))
                return false;
            if (Fecha == null)
                return false;
            return true;
        }
    }
}
