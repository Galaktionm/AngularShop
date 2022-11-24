namespace Gateway.Entities
{
    public class Laptop : Item
    {
        public string brand { get; set; }

        public string model { get; set; }

        public int ram { get; set; }

        public Laptop() { }

        public Laptop(long id, int price, int available, string brand, string model, int ram) : base(id, price, available)
        {
            this.brand = brand;
            this.model = model;
            this.ram = ram;
        }

    }
}
