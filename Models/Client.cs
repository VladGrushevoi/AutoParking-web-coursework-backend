using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Client
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Phone {get; set;}

        [NotMapped]
        public User User {get; set;}
    }
}