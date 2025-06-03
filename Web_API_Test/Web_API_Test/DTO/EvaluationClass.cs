namespace Web_API_Test.Classes
{
    public class EvaluationDto
    {
        public class EvaluationInfo
        {
            public int EmployeeId { get; set; }
            public DateTime EvaluationDate { get; set; }
            public string? Comments { get; set; }
        }
        public class EvaluationByEmployee
        {
            public int Id { get; set; }
            public int EmployeeId { get; set; }
            public DateTime EvaluationDate { get; set; }
            public string? Comments { get; set; }
        }
        public class KpiClass
        {
            public string KPIName { get; set; } = null!;
            public decimal Score { get; set; }
        }
    }
}
