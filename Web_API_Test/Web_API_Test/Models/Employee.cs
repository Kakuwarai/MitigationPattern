using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_API_Test.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName is required.")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Position is required.")]
        public string Position { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}
