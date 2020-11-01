using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Registration
    {
        public string Login {get; set;}
        public string Password {get; set;}
        public string FirstName {get; set;}
        public string SurName {get; set;}
        public string Phone {get; set;}
    }
}