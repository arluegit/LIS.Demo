using LIS.Domain.Entities;
using LIS.Domain.Enums;

namespace LIS.Application.Interfaces
{
    public interface ILabOrderWorkflowService
    {
        void ChangeStatus(
            LabOrder order,
            OrderStatus targetStatus,
            string roleName
        );
    }
}
