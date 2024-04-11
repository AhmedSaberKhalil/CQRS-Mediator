using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Repository;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSAndMediatRDemo.Handlers
{
	public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
	{
		private readonly IRepository<Order> _orderRepository;

		public CreateOrderHandler(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var orderDetails = new Order()
			{
				OrderName = request.OrderName,
				OrderPrice = request.OrderPrice,
				OrderAddress = request.OrderAddress,
				OrderDetails = request.OrderDetails
			};

			return await _orderRepository.AddOrderAsync(orderDetails);

		}
	}
}
