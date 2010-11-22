using System;

namespace SunnyTrail.Tests
{
    class EventHelper
    {
        public static Event CreateEvent()
        {
            return new Event
            {
                Id = 1,
                Action = new EventAction { Type = EventActionType.Signup, Created = DateTime.UtcNow },
                Email = "matt@litmus.com",
                Name = "Matthew Brindley",
                Plan = new EventPlan { Name = "Basic Trial 49", Price = 49.0, Recurring = 31 }
            };
        }
    }
}
