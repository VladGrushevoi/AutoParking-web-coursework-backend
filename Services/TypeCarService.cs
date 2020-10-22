using System.Collections.Generic;
using System.Linq;
using AutoParking_backend;
using Models;

namespace Services
{
    public class TypeCarService
    {
        private AppContext _context;

        public TypeCarService(AppContext context)
        {
            this._context = context;
        }

        public List<TypeCar> InitType()
        {
            _context.typeCars.AddAsync(new TypeCar{
                TypeCarName = "Легковик"
            });
            _context.typeCars.AddAsync(new TypeCar{
                TypeCarName = "Вантажівка"
            });
            _context.SaveChangesAsync();
            
            return _context.typeCars.ToList();
        }
    }
}