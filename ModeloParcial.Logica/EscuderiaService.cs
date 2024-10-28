using Microsoft.EntityFrameworkCore;
using ModeloParcial.Datos.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Logica;

public interface IEscuderiaService
{
    Task<List<Escuderium>> GetAllAsync();
}

public class EscuderiaService: IEscuderiaService
{
    private readonly Formula1Context _context;

    public EscuderiaService(Formula1Context context)
    {
        _context = context;
    }

    public async Task<List<Escuderium>> GetAllAsync()
    {
        return await _context.Escuderia
            .OrderBy(e => e.NombreEscuderia)
            .ToListAsync();
    }
}


