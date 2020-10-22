using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TypePlace
    {
        [Key]
        public int TypeId {get; set;}
        public string TypeName {get; set;}

        public List<Place> Places {get; set;}
    }
}