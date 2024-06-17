namespace ApiPeaje.Models
{
    public class Peaje
    {
        [Key]

        public int PeajeId { get; set; }
        [Required]

        public string Placa { get; set; }
        [Required]

        public string NombrePeaje { get; set; }
        [Required]

        public string IdCategoriaTarifa { get; set; }
        [Required]

        public DateTime FechaRegistro { get; set; }
        [Required]

        public decimal Valor { get; set; }
    }
}
