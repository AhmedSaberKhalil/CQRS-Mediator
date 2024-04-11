using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
	public class DeleteOrderCommand : IRequest<int>
	{
        public int OrderId { get; set; }
    }
}
