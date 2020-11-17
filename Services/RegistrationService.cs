using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoParking_backend;
using Models;

namespace Services
{
    public class RegistrationService
    {
        private AppContext _context;

        public RegistrationService(AppContext context)
        {
            this._context = context;
        }

        public User RegistrationUser(Registration reg)
        {   
            if(ChekLogin(reg.Login))
            {
                return null;
            }
            _context.users.AddAsync(new User{
                Login = reg.Login,
                Password = reg.Password,
                ClientId = AddNewClient(new Client{FirstName = reg.FirstName, LastName = reg.SurName, Phone = reg.Phone})
            });
            _context.SaveChangesAsync();
            return _context.users.OrderByDescending(c => c.UserId).First();
        }

        public User AuthUser(Authorization authorization)
        {
            if(CheckUser(authorization))
            {
                return _context.users.Where<User>(u => u.Login == authorization.Login).First();
            }
            return null;
        }

        private bool CheckUser(Authorization authorization)
        {
            foreach(var u in _context.users)
            {
                if(u.Login == authorization.Login && u.Password == authorization.Password)
                {
                    return true;
                }
            }

            return false;
        }

        internal User UpdateUser(int id,User user)
        {
            var upUser = _context.users.FirstOrDefault(u => u.UserId == id);
            if(upUser != null)
            {
                upUser.Login = user.Login;
                upUser.Password = user.Password;
            }
            _context.SaveChangesAsync();
            return _context.users.Where(u => u.UserId == id).First();
        }

        private int AddNewClient(Client client)
        {
            _context.clients.AddAsync(client);
            _context.SaveChangesAsync();
            return _context.clients.OrderByDescending(c => c.Id).FirstOrDefault().Id;
        }

        private bool ChekLogin(string login)
        {
            foreach(var u in _context.users)
            {
                if(u.Login == login)
                {
                    return true;
                }
            }

            return false;
        }


        ///=========================================///
        ///         Ініціалізація інфи              ///

        public Task<List<User>> InitClient()
        {
            _context.users.AddAsync(new User{
                    Login = $"admin",
                    Password = $"1111",
                    ClientId = 1
                });
            
            _context.SaveChangesAsync();
            return Task.Run(() => _context.users.ToList());
        }
    }
}