using System.Text.Json.Serialization;

namespace Test_API_LTSEDU.Model.Entity
{
    public class ProductDetailPropertyDetails
    {
        public int Id { get; set; }
        public int ProductDetailsId { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ProductDetails? ProductDetails { get; set; }
        public int PropertyDetailsId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PropertyDetails? PropertyDetails { get; set; }
        public int ProductsId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Products? Products { get; set; }
    }
}
