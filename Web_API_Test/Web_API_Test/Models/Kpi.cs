using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_API_Test.Models
{
    public class Kpi
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EvaluationId { get; set; }
        [Required]
        public string KPIName { get; set; } = null!;
        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
        public decimal Score { get; set; }
        [JsonIgnore]
        public Evaluation Evaluation { get; set; } = null!;
        }

    }
