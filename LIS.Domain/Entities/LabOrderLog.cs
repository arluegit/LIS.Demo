namespace LIS.Domain.Entities
{
    public class LabOrderLog
    {
        public int Id { get; set; }

        public int LabOrderId { get; set; }

        public string Action { get; set; } = string.Empty;
        // 例：StatusChanged: Ordered -> Testing

        public string PerformedBy { get; set; } = string.Empty;
        // 使用者帳號或 UserId

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public LabOrder? LabOrder { get; set; }
    }
}
