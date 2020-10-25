using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Place
    {
        [Key]
        public int PlaceId {get; set;}
        public int TypeId {get; set;}
        public int TypeCarId {get; set;}
        public int ParkingId {get; set;}        
        public double Price {get; set;}

        [NotMapped]
        public TypeCar TypeCar {get; set;}
        [NotMapped]
        public TypePlace TypePlace {get; set;}
        [NotMapped]
        public Parking Parking {get; set;}
    }
}