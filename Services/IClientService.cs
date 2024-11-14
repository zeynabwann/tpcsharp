using Cours.Models;

namespace Cours.Services;

public interface IClientService{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<IEnumerable<Client>> GetClientsPaginatedAsync(int pageNumber, int pageSize);

    Task<Client> Create(Client client);
 
    
}
