namespace Code
{
    public class Floor
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public int NumberOfRooms { get; set; }

        public Building Building { get; set; }
    }
}
