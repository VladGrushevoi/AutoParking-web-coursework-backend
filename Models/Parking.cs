using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Parking
    {
        [Key]
        public int ParkingId {get; set;}
        public string Name {get; set;}
        public string Description{get; set;}
        public string UrlImg {get; set;}

        public List<Place> Places {get; set;}
    }
}