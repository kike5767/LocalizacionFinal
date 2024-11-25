using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Auditoria
    {
        [Key] public int Id { get; set; }
        public string? Tabla { get; set; }
        [Key] public int Referencia { get; set; }
        public string? Accion { get; set; }
    }
}