using System.ComponentModel.DataAnnotations;

namespace ContctosApi4.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Cedula { get; set; }

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Imagen { get; set; }


    }
}
