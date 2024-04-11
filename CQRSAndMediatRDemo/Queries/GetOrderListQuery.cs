using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries
{
	public class GetOrderListQuery : IRequest<List<Order>>
	{
	}
}
