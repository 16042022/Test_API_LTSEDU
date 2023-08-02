using System.Text.Json.Serialization;

namespace Test_API_LTSEDU.Model.Entity
{
    public class PropertyDetails
    {
        public int Id { get; set; }
        public int PropertiesId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Properties? Properties { get; set; }
        public string? PropertyDetailCode { get; set; }
        public string? PropertyDetailDetail { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<ProductDetailPropertyDetails>? ProductDetailPropertyDetails{ get; set; }
    }
}
