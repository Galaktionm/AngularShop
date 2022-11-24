using System.Text.Json.Serialization;

namespace Gateway.Entities
{
    
    [JsonDerivedType(typeof(Book))]
    public class Item
    {
        public long id { get; set; }

        public int price { get; set; }

        public int available { get; set; }

        public Item() { }

        public Item(long id, int price, int available)
        {
            this.id = id;
            this.price = price;
            this.available = available;
        }

    }
}
