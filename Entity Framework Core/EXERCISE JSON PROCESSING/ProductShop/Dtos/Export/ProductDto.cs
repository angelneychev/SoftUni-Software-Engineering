using Newtonsoft.Json;

namespace ProductShop.Dtos.Export
{
    public class ProductDto
    {
        [JsonProperty(propertyName:"name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "price")]
        public decimal Price { get; set; }
        //Seller.FirstName Seller.LastName
        [JsonProperty(propertyName: "seller")]
        public string Seller { get; set; }
    }
}