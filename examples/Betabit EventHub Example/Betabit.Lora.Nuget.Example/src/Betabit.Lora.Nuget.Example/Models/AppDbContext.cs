using Microsoft.Data.Entity;

namespace Betabit.Lora.Nuget.Example.Models
{
	/// <summary>
	/// The application database context.
	/// </summary>
	/// <seealso cref="Microsoft.Data.Entity.DbContext" />
	public class AppDbContext : DbContext
	{
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
