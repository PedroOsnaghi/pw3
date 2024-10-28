using Microsoft.AspNetCore.Mvc;
using ModeloParcial.Datos.EF;
using ModeloParcial.Logica;
using ModeloParcial.Web.Models;
using System.Diagnostics;

namespace ModeloParcial.Web.Controllers;

public class PilotoController : Controller
{
    private readonly IPilotoService _pilotoService;
    private readonly IEscuderiaService _escuderiaService;

    public PilotoController(IPilotoService pilotoService, IEscuderiaService escuderiaService)
    {
        _escuderiaService = escuderiaService;
        _pilotoService = pilotoService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> AgregarPiloto()
    {
        ViewBag.Escuderias = await _escuderiaService.GetAllAsync();
        ViewBag.EscuderiaSelectedId = 0;
        return View("NuevoPiloto", new PilotoViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> AgregarPiloto(PilotoViewModel model)
    {
        if(ModelState.IsValid)
        {
            var piloto = new Piloto
            {
                NombrePiloto = model.Nombre,
                IdEscuderia = model.IdEscuderia
            };
            await _pilotoService.CreateAsync(piloto);

            return RedirectToAction("ListarPilotos");
        }

        ViewBag.Escuderias = await _escuderiaService.GetAllAsync();
        ViewBag.EscuderiaSelectedId = model.IdEscuderia;
        return View("NuevoPiloto", model);
    }

    public async Task<IActionResult> ListarPilotos(int idEscuderia = 0)
    {
        var pilotos = idEscuderia == 0
                       ? await _pilotoService.GetAllAsync()
                       : await _pilotoService.GetAllByEscuderiaAsync(idEscuderia);
                        
        ViewBag.Escuderias = await _escuderiaService.GetAllAsync();
        ViewBag.EscuderiaSelectedId = idEscuderia;
        return View("ListarPilotos", pilotos);
    }

    public async Task<IActionResult> EliminarPiloto(int? id, int idEscuderia = 0)
    {
        if(id.HasValue)
        {
            await _pilotoService.DeleteAsync(id.Value);
        }

        return RedirectToAction("ListarPilotos", new { idEscuderia = idEscuderia });
    }




}
