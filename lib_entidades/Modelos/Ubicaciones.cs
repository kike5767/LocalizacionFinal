// Librerias
using System.ComponentModel.DataAnnotations;

// Proyecto
namespace lib_entidades.Modelos
{
    // La clase representa las coordenadas geograficas exactas
    public class Ubicaciones
    {
        // Atributos y propiedades
        [Key] public int Id { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public bool Activo { get; set; }
        public string test {  get; set; }

        // Metodos
        public bool Validar()
        {
            if (Activo == true)
                return false;
            return true;
        }
    }
}
