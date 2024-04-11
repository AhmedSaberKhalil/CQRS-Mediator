using CQRSAndMediatRDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Data
{
	public class CQRSMediatREntity : IdentityDbContext<IdentityUser>
	{
        public CQRSMediatREntity(DbContextOptions<CQRSMediatREntity> options) : base(options)
        {
            
        }
        public CQRSMediatREntity()
        {
            
        }
        public DbSet<Order> Order { get; set; }
}
}
