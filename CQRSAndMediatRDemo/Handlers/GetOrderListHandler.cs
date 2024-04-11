using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using CQRSAndMediatRDemo.Repository;
using MediatR;

namespace CQRSAndMediatRDemo.Handlers
{
	public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<Order>>
	{
		private readonly IRepository<Order> _orderRepository;

		public GetOrderListHandler(IRepository<Order> orderRepository)
		{
			_orderRepository = orderRepository;
		}
		public async Task<List<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
		{
			return await _orderRepository.GetOrderListAsync();
		}
	}
}
