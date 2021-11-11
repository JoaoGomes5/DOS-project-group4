namespace Code.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public int SquareMeters { get; set; }
        public int NumberOfRooms { get; set; }

        public Owner Owner { get; set; }

        public Floor Floor { get; set; }
    
    
    }
}
