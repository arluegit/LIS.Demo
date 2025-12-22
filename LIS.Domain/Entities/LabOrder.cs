// Entities/LabOrder.cs
using LIS.Domain.Enums;

namespace LIS.Domain.Entities
{
    public class LabOrder
    {
        public int OrderId { get; private set; }

        public OrderStatus Status { get; private set; } = OrderStatus.Ordered;

        public DateTime OrderedAt { get; private set; } = DateTime.UtcNow;

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (!IsValidStatusTransition(Status, newStatus))
            {
                throw new InvalidOperationException(
                    $"Invalid status transition: {Status} → {newStatus}"
                );
            }

            Status = newStatus;
        }

        private bool IsValidStatusTransition(OrderStatus current, OrderStatus next)
        {
            return current switch
            {
                OrderStatus.Ordered => next == OrderStatus.Received,
                OrderStatus.Received => next == OrderStatus.InProgress,
                OrderStatus.InProgress => next == OrderStatus.Completed,
                OrderStatus.Completed => next == OrderStatus.Reported,
                _ => false
            };
        }
    }
}
