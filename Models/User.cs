using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        public int UserId {get; set;}
        public string Login {get; set;}
        public string Password {get; set;}
        public int ClientId {get; set;}

        [NotMapped]
        public List<Client> Client{get; set;}
    }
}