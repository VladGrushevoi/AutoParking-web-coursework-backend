using System.Collections.Generic;
using System.Linq;
using AutoParking_backend;
using Models;

namespace Services
{
    public class TypePlaceService
    {
        private AppContext _context;

        public TypePlaceService(AppContext context)
        {
            this._context = context;
        }

        public List<TypePlace> InitPlace()
        {
            _context.typePlaces.AddAsync(new TypePlace{
                TypeName = "Без накриття"
            });
            _context.typePlaces.AddAsync(new TypePlace{
                TypeName = "З накриттям"
            });

            _context.SaveChangesAsync();

            return _context.typePlaces.ToList();
        }
    }    
}