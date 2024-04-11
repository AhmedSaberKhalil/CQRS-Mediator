using CQRSAndMediatRDemo.Commands;
using CQRSAndMediatRDemo.Models;
using CQRSAndMediatRDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace CQRSAndMediatRDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private const string orderListCacheKey = "orderList";

		private readonly IMediator mediator;
		private readonly IMemoryCache _cache;

		public OrderController(IMediator mediator, IMemoryCache cache)
		{
			this.mediator = mediator;
			this._cache = cache;
		}

		[HttpGet]
		public async Task<List<Order>> GetStudentListAsync()
		{
			if (!_cache.TryGetValue(orderListCacheKey, out List<Order> order))
			{
				order = await mediator.Send(new GetOrderListQuery()); // Get the data from database
				var cacheEntryOptions = new MemoryCacheEntryOptions
				{
					AbsoluteExpiration = DateTime.Now.AddMinutes(1),
					SlidingExpiration = TimeSpan.FromMinutes(1),
					Size = 1024,
				};
				_cache.Set(orderListCacheKey, order, cacheEntryOptions);
			}

			//var studentDetails = await mediator.Send(new GetOrderListQuery());

			return order;
		}

		[HttpGet("OrderId")]
		public async Task<Order> GetStudentByIdAsync(int orderId)
		{
			var studentDetails = await mediator.Send(new GetOrderByIdQuery() { OrderId = orderId });

			return studentDetails;
		}

		[HttpPost]
		public async Task<Order> AddStudentAsync(Order orderDetails)
		{
			var orderDetail = await mediator.Send(new CreateOrderCommand(
				orderDetails.OrderName,
				orderDetails.OrderPrice,
				orderDetails.OrderAddress,
				orderDetails.OrderDetails));
			return orderDetail;
		}

		[HttpPut]
		public async Task<int> UpdateStudentAsync(Order orderDetails)
		{
			var orderDetail = await mediator.Send(new UpdateOrderCommand(
			   orderDetails.OrderId,
			   orderDetails.OrderName,
				orderDetails.OrderPrice,
				orderDetails.OrderAddress,
				orderDetails.OrderDetails));
			return orderDetail;
		}

		[HttpDelete]
		public async Task<int> DeleteStudentAsync(int Id)
		{
			return await mediator.Send(new DeleteOrderCommand() { OrderId = Id });
		}
	}
}
