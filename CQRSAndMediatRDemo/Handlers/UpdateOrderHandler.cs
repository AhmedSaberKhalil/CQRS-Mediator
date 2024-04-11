using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repository;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSAndMediatRDemo.Handlers
{
	public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, int>
	{
		private readonly IRepository<Order> _orderRepository;

		public UpdateOrderHandler(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{

			Order orderDetails = await _orderRepository.GetOrdertByIdAsync(request.OrderId);
			if (orderDetails == null)
				return default;

			orderDetails.OrderName = request.OrderName;
			orderDetails.OrderPrice = request.OrderPrice;
			orderDetails.OrderAddress = request.OrderAddress;
			orderDetails.OrderDetails = request.OrderDetails;

			return await _orderRepository.UpdateOrderAsync(orderDetails);
		}
	}
}
