using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Test_API_LTSEDU.Model.Entity
{
    public class Products
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<Properties>? Properties { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<ProductDetailPropertyDetails>? Details { get; set; }
    }
}
