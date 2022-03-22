using System.Text.Json.Serialization;

namespace TesteWebMotors.Dominio.Models
{
    public class AnuncioAPIMakes
    {
        [JsonPropertyName("ID")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}