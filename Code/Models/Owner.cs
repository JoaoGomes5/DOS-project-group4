using System.Collections.Generic;

namespace Code.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
    
        public ICollection<Flat> Flats { get; set;}
    }
}