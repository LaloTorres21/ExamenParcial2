using System.ComponentModel.DataAnnotations;

namespace ExamenParcial2.Model;

public class Participante
{
    public int Id { get; set; }
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "Los apellidos son requeridos")]
    public string Apellidos { get; set; } = string.Empty;
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    public string Email { get; set; } = string.Empty;
    
    public string UsuarioTwitter { get; set; } = string.Empty;
    [Required(ErrorMessage = "La ocupación es requerida")]
    public string Ocupacion { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;
    [Required(ErrorMessage = "Debes aceptar los términos y condiciones")]
    public bool AceptaTerminos { get; set; }
}