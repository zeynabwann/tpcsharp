using Cours.Data;
using Cours.Models;
using Microsoft.EntityFrameworkCore;


namespace Cours.Services.Impl;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;

    public ClientService(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<Client>> GetClientsPaginatedAsync(int pageNumber, int pageSize)
    {
        return await _context.Clients
                             .OrderBy(c => c.Id)
                             .Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
    }

    public async Task<Client> Create(Client client)
    {
        
        _context.Clients.Add(client);
        
        await _context.SaveChangesAsync();

        return client;
    }

    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }
}