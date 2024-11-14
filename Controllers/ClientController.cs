using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TAFCSHARP.Models;
using Cours.Services;
using Cours.Models;

namespace GestionDette.Controllers;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(ILogger<ClientController> logger, IClientService clientService)
    {
        _logger = logger;
        _clientService = clientService;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 15)
    {
        var clients = await _clientService.GetClientsPaginatedAsync(pageNumber, pageSize);
        var totalClients = (await _clientService.GetClientsAsync()).Count();
        var totalPages = (int)Math.Ceiling(totalClients / (double)pageSize);
        return View(clients);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Surnom,Telephone,Adresse")] Client client)
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"***********************************************{client.Adresse}***********************************************");
            var clientAdded = await _clientService.Create(client);

            TempData["Message"] = "Client créé avec succès!";
            return RedirectToAction(nameof(Index));
        }
        return View(client);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}