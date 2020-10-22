using System.ComponentModel.DataAnnotations;

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

        public TypeCar TypeCar {get; set;}
        public TypePlace TypePlace {get; set;}
        public Parking Parking {get; set;}
    }
}