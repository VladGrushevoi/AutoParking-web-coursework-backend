namespace Models
{
    public class Parking
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description{get; set;}

        public Parking(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }

        public Parking(){

        }
    }
}