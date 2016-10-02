using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Betabit.Lora.Nuget.Example.Models
{
	/// <summary>
	/// The application database context.
	/// </summary>
	/// <seealso cref="DbContext" />
	public class AppDbContext : DbContext
	{
	    public AppDbContext(DbContextOptions options) : base(options)
	    {
	    }

	    /// <summary>
		/// The database context for rooms
		/// </summary>
		public DbSet<Room> Rooms { get; set; }

		/// <summary>
		/// The database context for devices
		/// </summary>
		public DbSet<Device> Devices { get; set; }
	}
}
