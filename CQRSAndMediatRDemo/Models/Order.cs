namespace CQRSAndMediatRDemo.Models
{
	public class Order
	{
		public int OrderId { get; set; }
		public string OrderName { get; set; }
		public float OrderPrice { get; set; }
		public string OrderDetails { get; set; }
		public string OrderAddress { get; set; }
	}
}
