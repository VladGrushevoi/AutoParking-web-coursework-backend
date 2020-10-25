using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{   
    public class Reserv
    {
        [Key]
        public int ReservId {get; set;}
        public int ClientId {get; set;}
        public int PlaceId {get; set;}
        public DateTime StartPeriod {get; set;}
        public DateTime EndPeriod {get; set;}
    }
}