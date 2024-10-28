using Microsoft.EntityFrameworkCore;
using ModeloParcial.Datos.EF;

namespace ModeloParcial.Logica;

public interface IPilotoService
{
    Task<Piloto> CreateAsync(Piloto piloto);

    Task<List<Piloto>> GetAllByEscuderiaAsync(int idEscuderia);

    Task<List<Piloto>> GetAllAsync();

    Task DeleteAsync(int idPiloto);
}

public class PilotoService : IPilotoService
{
    private readonly Formula1Context _context;

    public PilotoService(Formula1Context context)
    {
        _context = context;
    }

    public async Task<Piloto> CreateAsync(Piloto piloto)
    {
        piloto.Eliminado = false;
        _context.Pilotos.Add(piloto);
        await _context.SaveChangesAsync();
        return piloto;
    }

    public async Task DeleteAsync(int idPiloto)
    {
        var piloto = await _context.Pilotos.FindAsync(idPiloto);
        if (piloto != null)
        {
            piloto.Eliminado = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Piloto>> GetAllAsync()
    {
        return await _context.Pilotos.Include(e => e.IdEscuderiaNavigation).Where(p => p.Eliminado == false).OrderByDescending(p => p.IdPiloto).ToListAsync();
    }

    public async Task<List<Piloto>> GetAllByEscuderiaAsync(int idEscuderia)
    {
        return await _context.Pilotos.Include(e => e.IdEscuderiaNavigation).Where(p => p.IdEscuderia == idEscuderia && p.Eliminado == false).OrderByDescending(p => p.IdPiloto).ToListAsync();
    }
}
