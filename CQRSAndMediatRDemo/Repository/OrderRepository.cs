using CQRSAndMediatRDemo.Data;
using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Repository
{
	public class OrderRepository : IRepository<Order>
	{
		private readonly CQRSMediatREntity _dbContext;

		public OrderRepository(CQRSMediatREntity dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Order> AddOrderAsync(Order order)
		{
			var result = _dbContext.Order.Add(order);
			await _dbContext.SaveChangesAsync();
			return result.Entity;
		}


		public async Task<int> DeleteOrderAsync(int Id)
		{
			Order filteredData = await GetOrdertByIdAsync(Id);
			_dbContext.Order.Remove(filteredData);
			return await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Order>> GetOrderListAsync()
		{
			return await _dbContext.Order.ToListAsync();
		}

		public async Task<Order> GetOrdertByIdAsync(int Id)
		{
			return await _dbContext.Order.FirstOrDefaultAsync(o => o.OrderId == Id);
		}


		public async Task<int> UpdateOrderAsync(Order order)
		{

			_dbContext.Order.Update(order);
			return await _dbContext.SaveChangesAsync();
		}

	}
}
