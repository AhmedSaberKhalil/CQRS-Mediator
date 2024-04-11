using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repository;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
	public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order>
	{
		private readonly IRepository<Order> _orderRepository;

		public GetOrderByIdHandler(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			return await _orderRepository.GetOrdertByIdAsync(request.OrderId);
		}
	}
}
