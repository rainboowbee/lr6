using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EventController : Controller
    {
        private readonly EventsContext _eventsContext;
        
        public EventController(EventsContext eventContext)
        {
            _eventsContext = eventContext;
        }

        public IActionResult Index()
        {
            List<Event> events = _eventsContext.Events.ToList();
            return View(events);
        }
    }
}
