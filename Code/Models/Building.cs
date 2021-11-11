using System.Collections.Generic;

﻿namespace Code.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public int FloorsNumber { get; set; }
        public string Country { get; set; }
        public ICollection<Floor> Floors { get; set; }

    }
}
