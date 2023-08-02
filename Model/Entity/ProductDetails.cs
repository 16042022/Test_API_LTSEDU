using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Test_API_LTSEDU.Model.Entity
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string? ProductPropertyName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double ShellPrice { get; set; }
        public int? ParentId { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ProductDetails? Parent { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<ProductDetails>? Children { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<ProductDetailPropertyDetails>? PropertyDetails { get; set; }
    }
}
