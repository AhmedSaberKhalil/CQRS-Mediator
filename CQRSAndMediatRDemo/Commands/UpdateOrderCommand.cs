using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
	public class UpdateOrderCommand : IRequest<int>
	{
		public int OrderId { get; set; }
		public string OrderName { get; set; }
		public float OrderPrice { get; set; }
		public string OrderDetails { get; set; }
		public string OrderAddress { get; set; }
		public UpdateOrderCommand(int OrderId, string OrderName, float OrderPrice, string OrderDetails, string OrderAddress)
		{
			this.OrderId = OrderId;
			this.OrderName = OrderName;
			this.OrderPrice = OrderPrice;
			this.OrderDetails = OrderDetails;
			this.OrderAddress = OrderAddress;
		}
	}
}
