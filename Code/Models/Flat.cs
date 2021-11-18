namespace Code.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public float SquareMeters { get; set; }
        public int NumberOfRooms { get; set; }

        public int OwnerId { get; set;}
        public Owner Owner { get; set; }
        public Floor Floor { get; set; }
    
    
    }
}
