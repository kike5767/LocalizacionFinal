// Librerias
using System.ComponentModel.DataAnnotations;

// Proyecto
namespace lib_entidades.Modelos
{
    // Esta clase sera la mas escencial ya que se relaciona con las demas para poder generar una localizacion
    public class Localizaciones
    {
        // Atributos y propiedades
        [Key] public int Id { get; set; }
        public int personas { get; set; }
        public int localidades { get; set; }
        public int ubicaciones { get; set; }
        public int imagenes { get; set; }
        public int detalles { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Activo { get; set; }
        public string? test {  get; set; }

        // Metodos
        public bool Validar()
        {
            if (personas < 10)
                return false;
            return true;
        }
    }
}
