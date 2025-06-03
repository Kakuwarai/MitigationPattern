
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_API_Test.Models
{
    public class Evaluation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime EvaluationDate { get; set; }
        public string? Comments { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Kpi> Kpis { get; set; } = new List<Kpi>();
    }
}
