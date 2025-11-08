using ExamenParcial2.Data;
using ExamenParcial2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamenParcial2.Controllers;

[ApiController]
[Route("api")]
public class ParticipantesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ParticipantesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("listado")]
    public async Task<ActionResult<IEnumerable<Participante>>> GetParticipantes(string? q = null)
    {
        IQueryable<Participante> query = _context.Participantes;
        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(p =>
                p.Nombre.Contains(q) ||
                p.Email.Contains(q) ||
                p.Apellidos.Contains(q) ||
                p.UsuarioTwitter.Contains(q) ||
                p.Ocupacion.Contains(q)
            );
        }

        var participantes = await query
            .OrderBy(p => p.Apellidos)
            .ThenBy(p => p.Nombre)
            .ToListAsync();
        
        return Ok(participantes);
    }

    [HttpGet("participante/{id}")]
    public async Task<ActionResult<Participante>> GetParticipante(int id)
    {
        var participante = await _context.Participantes.FindAsync(id);
        if (participante == null)
        {
            return NotFound(new { message = "Participante no encontrado" });
        }

        return Ok(participante);
    }

    [HttpPost("registro")]
    public async Task<ActionResult<Participante>> PostParticipante(Participante participante)
    {
        if (!participante.AceptaTerminos)
        {
            return BadRequest(new { message = "Debe de aceptar los términos y condiciones" });
        }
        
        var emailExiste = await _context.Participantes
            .AnyAsync(p => p.Email == participante.Email);

        if (emailExiste)
        {
            return BadRequest(new { message = "Participante existe" });
        }

        _context.Participantes.Add(participante);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetParticipante), new { id = participante.Id }, participante);
    }
}