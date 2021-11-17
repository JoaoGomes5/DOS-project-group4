using System.Collections.Generic;

namespace Code.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int NumberOfRooms { get; set; }
        public int BuildingId { get; set;}
        public Building Building { get; set; }
        public ICollection<Flat> Flats { get; set;}
    }
}   
