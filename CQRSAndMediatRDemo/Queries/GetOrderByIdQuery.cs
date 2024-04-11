using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Queries
{
	public class GetOrderByIdQuery : IRequest<Order>
	{
        public int OrderId { get; set; }
    }
}
