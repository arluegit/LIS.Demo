using System;
using System.Threading.Tasks;
using LIS.Domain.Entities;
using LIS.Domain.Enums;
using LIS.Application.Interfaces;

namespace LIS.Application.Services
{
    public class LabOrderService
    {
        private readonly ILabOrderRepository _repository;

        public LabOrderService(ILabOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task ChangeStatusAsync(
            int labOrderId,
            OrderStatus newStatus,
            string performedBy)
        {
            var order = await _repository.GetByIdAsync(labOrderId);

            if (order == null)
                throw new Exception("LabOrder not found");

            order.ChangeStatus(newStatus);

            await _repository.SaveChangesAsync();
        }
    }
}
