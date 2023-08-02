using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Test_API_LTSEDU.Model.Entity
{
    public class Properties
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        [JsonIgnore (Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Products? Products { get; set; }
        public string? PropertyName { get; set; }
        public int PropertySort { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<PropertyDetails>? PropertyDetails { get; set; }
    }
}
