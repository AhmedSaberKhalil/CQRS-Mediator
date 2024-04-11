using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repository;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
	public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, int>
	{
		private readonly IRepository<Order> _studentRepository;

		public DeleteOrderHandler(IRepository<Order> orderRepository)
		{
			_studentRepository = orderRepository;
		}

		public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
		{
			Order orderDetails = await _studentRepository.GetOrdertByIdAsync(request.OrderId);
			if (orderDetails == null)
				return default;

			return await _studentRepository.DeleteOrderAsync(orderDetails.OrderId);
		}

	}
}
