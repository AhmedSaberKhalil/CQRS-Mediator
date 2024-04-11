using CQRSAndMediatRDemo.Models;

namespace CQRSAndMediatRDemo.Repository
{
	public interface IRepository<T> where T : class
	{
		public Task<List<Order>> GetOrderListAsync();
		public Task<Order> GetOrdertByIdAsync(int Id);
		public Task<Order> AddOrderAsync(Order order);
		public Task<int> UpdateOrderAsync( Order order);
		public Task<int> DeleteOrderAsync(int Id);
	}
}
