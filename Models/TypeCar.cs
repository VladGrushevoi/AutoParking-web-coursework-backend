using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypeCar
    {
        [Key]
        public int TypeCarId {get; set;}
        public string TypeCarName {get; set;}

        public List<Place> Places {get; set;}
    }
}