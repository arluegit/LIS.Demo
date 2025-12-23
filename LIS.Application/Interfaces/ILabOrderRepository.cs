using LIS.Domain.Entities;

namespace LIS.Application.Interfaces
{
    public interface ILabOrderRepository
    {
        Task<LabOrder?> GetByIdAsync(int id);
        Task SaveChangesAsync();
    }
}
