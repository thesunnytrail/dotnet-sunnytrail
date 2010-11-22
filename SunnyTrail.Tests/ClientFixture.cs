using System;
using NUnit.Framework;

namespace SunnyTrail.Tests
{
    [TestFixture]
    public class ClientFixture
    {
        private const string ApiKey = "your_api_key";

        [Test]
        public void SaveEvent_WithValidEvent_ShouldNotThrow()
        {
            new Client(ApiKey).SaveEvent(EventHelper.CreateEvent());
        }

        [Test, ExpectedException(typeof(UnableToSaveEventException))]
        public void SaveEvent_WithInvalidEmail_ShouldThrow()
        {
            var client = new Client(ApiKey);
            var evnt = EventHelper.CreateEvent();
            evnt.Email = "matt@litmus";
            client.SaveEvent(evnt);
        }

        [Test, ExpectedException(typeof(UnableToSaveEventException)), Description("Known issue with SunnyTrail, email field can't accept plus symbol")]
        public void SaveEvent_WithValidEmailWithPlus_ShouldThrow()
        {
            var client = new Client(ApiKey);
            var evnt = EventHelper.CreateEvent();
            evnt.Email = "matt+test@litmus.com";
            client.SaveEvent(evnt);
        }
        
        [Test, ExpectedException(typeof(UnableToSaveEventException)), Description("Known issue with SunnyTrail, email field can't accept plus symbol")]
        public void SaveEvent_WithValidNameWithAmpersand_ShouldThrow()
        {
            var client = new Client(ApiKey);
            var evnt = EventHelper.CreateEvent();
            evnt.Name = "Mumford & Sons";
            client.SaveEvent(evnt);
        }
        
        [Test, ExpectedException(typeof(ArgumentException))]
        public void SaveEvent_WithEventWithNullPlan_ShouldThrow()
        {
            var client = new Client(ApiKey);
            var evnt = EventHelper.CreateEvent();
            evnt.Plan = null;
            client.SaveEvent(evnt);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void SaveEvent_WithEventWithNullAction_ShouldThrow()
        {
            var client = new Client(ApiKey);
            var evnt = EventHelper.CreateEvent();
            evnt.Plan = null;
            client.SaveEvent(evnt);
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void SaveEvent_WithEventWithIdOf0_ShouldThrow()
        {
            var client = new Client(ApiKey);
            var evnt = EventHelper.CreateEvent();
            evnt.Id = 0;
            client.SaveEvent(evnt);
        }
    }
}
