using CQRSAndMediatRDemo.Models;
using MediatR;

namespace CQRSAndMediatRDemo.Commands
{
	public class CreateOrderCommand : IRequest<Order>
	{
		public string OrderName { get; set; }
		public float OrderPrice { get; set; }
		public string OrderDetails { get; set; }
		public string OrderAddress { get; set; }
		public CreateOrderCommand(string OrderName, float OrderPrice, string OrderDetails, string OrderAddress)
        {
            this.OrderName = OrderName;
			this.OrderPrice = OrderPrice;
			this.OrderDetails = OrderDetails;
			this.OrderAddress = OrderAddress;
        }
    }
}
