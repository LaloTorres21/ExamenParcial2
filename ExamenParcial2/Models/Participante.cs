using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExamenParcial2.Model;

public class Participante
{
    public int Id { get; set; }
    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = string.Empty;
    [JsonPropertyName("apellidos")]
    public string Apellidos { get; set; } = string.Empty;
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
    [JsonPropertyName("usuarioTwitter")]
    public string UsuarioTwitter { get; set; } = string.Empty;
    [JsonPropertyName("ocupacion")]
    public string Ocupacion { get; set; } = string.Empty;
    [JsonPropertyName("avatar")]
    public string Avatar { get; set; } = string.Empty;
    [JsonPropertyName("aceptaTerminos")]
    public bool AceptaTerminos { get; set; }
}