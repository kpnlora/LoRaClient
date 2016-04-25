using Betabit.Lora.Nuget.Example.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Betabit.Lora.Nuget.Example.Controllers
{
	/// <summary>
	/// This controller is used to manage Rooms.
	/// It mainly consists of basic CRUD operations.
	/// </summary>
	/// <seealso cref="Betabit.Lora.Nuget.Example.Controllers.BaseController" />
	public class RoomsController : BaseController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RoomsController"/> class.
		/// </summary>
		/// <param name="configuration">The application configuration.</param>
		/// <param name="appDbContext">The application database context.</param>
		public RoomsController(IConfigurationRoot configuration, AppDbContext appDbContext)
			: base(configuration, appDbContext)
		{
		}

		[HttpGet]
		public IActionResult Index()
		{
			// Retrieve all the rooms from the context
			var rooms = _context.Rooms.ToList();

			// Render the overview with the rooms
			return View(rooms);
		}

		[HttpGet]
		public IActionResult Details(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct room using the ID
			var room = _context.Rooms.Single(m => m.Id == id.Value);

			if (room == null)
			{
				// If no room could be found, show a 404 page
				return HttpNotFound();
			}

			// Render the details view with the room
			return View(room);
		}

		[HttpGet]
		public IActionResult Create()
		{
			// Render the creation view
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Room room)
		{
			// Make sure the model is valid
			if (ModelState.IsValid)
			{
				// Add the room
				_context.Rooms.Add(room);
				_context.SaveChanges();

				// Redirect the user back to the index page
				return RedirectToAction("Index");
			}

			// If the model is not valid, show the view again with the errors
			return View(room);
		}

		public IActionResult Edit(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct room using the ID
			var room = _context.Rooms.Single(m => m.Id == id.Value);

			if (room == null)
			{
				// If no room could be found, show a 404 page
				return HttpNotFound();
			}

			// Render the details view with the room
			return View(room);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Room room)
		{
			// Make sure the model is valid
			if (ModelState.IsValid)
			{
				// Update the room
				_context.Rooms.Update(room);
				_context.SaveChanges();

				// Redirect the user back to the index page
				return RedirectToAction("Index");
			}

			// If the model is not valid, show the view again with the errors
			return View(room);
		}

		[ActionName("Delete")]
		public IActionResult Delete(int? id)
		{
			// Make sure we have a valid ID
			if (id == null)
			{
				return HttpNotFound();
			}

			// Find the correct room using the ID
			var room = _context.Rooms.Single(m => m.Id == id.Value);

			if (room == null)
			{
				// If no room could be found, show a 404 page
				return HttpNotFound();
			}

			// Render the details view with the room
			return View(room);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			// Find the room using the unique identifier
			var room = _context.Rooms.Single(m => m.Id == id);

			// Remove the room
			_context.Rooms.Remove(room);
			_context.SaveChanges();

			// Redirect the user back to the index page
			return RedirectToAction("Index");
		}
	}
}