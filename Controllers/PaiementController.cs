using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TAFCSHARP.Models;
using Cours.Services;
using Cours.Services.Impl;

namespace GestionDette.Controllers;

public class PaiementController : Controller
{
    private readonly ILogger<PaiementController> _logger;
    private readonly IPaiementService _paiementService;
    public PaiementController(ILogger<PaiementController> logger, IPaiementService paiementService)
    {
        _logger = logger;
        _paiementService = paiementService;
    }
    public async Task<IActionResult> Index()
    {
        
        return View();
    }

    public async Task<IActionResult> PaiementsDette(int Id)
    {
        var paiementsDette = await _paiementService.GetDettePaiementsAsync(Id);
        return View(paiementsDette);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}