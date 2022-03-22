using System.ComponentModel.DataAnnotations;

namespace TesteWebMotors.Dominio.Models
{
    public class AnuncioWeb
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(45)]
        public string Marca { get; set; }

        [Required]
        [MaxLength(45)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(45)]
        public string Versao { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Quilometragem { get; set; }

        [Required]
        public string Observacao { get; set; }
    }
}
