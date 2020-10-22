using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoParking_backend;
using Models;

namespace Services
{
    public class ClientService
    {
        private AppContext _context;

        public ClientService(AppContext context)
        {
            this._context = context;
        }

        public Task<Client> AddClient(Client c)
        {
            _context.clients.AddAsync(c);
            _context.SaveChangesAsync();

            return Task.Run(() => _context.clients.OrderByDescending(c => c.Id).FirstOrDefault());
        }

        public Task<List<Client>> GetAllClients() => Task.Run(() => _context.clients.ToList());
        

        public Task<Client> GetClientById(int id) => Task.Run(() => _context.clients.Find(id));


        ///=========================================///
        ///         Ініціалізація інфи              ///

        public Task<List<Client>> InitClient()
        {
            for(int i = 0; i < 5; i++)
            {
                _context.clients.AddAsync(new Client{
                    FirstName = $"Циган-{i+1}",
                    LastName = $"Циганенко-{i+1}",
                    Phone = "1488228322"
                });
            }
            _context.SaveChangesAsync();
            return Task.Run(() => _context.clients.ToList());
        }
    }    
}