using System;

namespace Models
{
    public class ReservModel
    {
        public int? ClientId {get;set;}
        public int? PlaceId {get; set;}
        public DateTime? StartPeriod {get; set;}
        public DateTime? EndPeriod {get; set;}
    }
}