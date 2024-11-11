// Librerias
using System.ComponentModel.DataAnnotations;

// Proyecto
namespace lib_entidades.Modelos
{
    // La clase proporcionara la informacion de una ubicacion geografica especifica 
    public class Localidades
    {
        // Atributos y propiedades
        [Key] public int Id { get; set; }
        public string? Pais { get; set; } 
        public string? Estado { get; set; } 
        public string? CodigoPostal { get; set; } 
        public string? Ciudad { get; set; }
        public string? Barrio { get; set; } 
        public string? Calle { get; set; }

        // Metodos
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Pais))
                return false;
            if (Estado == null)
                return false;
            return true;
        }
    }
}
