using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace SunnyTrail.Tests
{
    [TestFixture]
    public class EventFixture
    {
        [Test]
        public void ToJson_WithValidEvent_ShouldReturnCorrectJson()
        {
            var evnt = EventHelper.CreateEvent();
            Assert.That(evnt.ToJson(), Is.EqualTo("{\"action\":{\"created\":" + EventAction.ConvertToUnixTimestamp(evnt.Action.Created) + ",\"name\":\"signup\"},\"email\":\"matt@litmus.com\",\"id\":1,\"name\":\"Matthew Brindley\",\"plan\":{\"name\":\"Basic Trial 49\",\"price\":49,\"recurring\":31}}"));
        }

        [Test]
        public void ToJson_WithValidEventButEscapedChars_ShouldReturnCorrectJson()
        {
            var evnt = EventHelper.CreateEvent();
            evnt.Email += "\"";
            Assert.That(evnt.ToJson(), Is.EqualTo("{\"action\":{\"created\":" + EventAction.ConvertToUnixTimestamp(evnt.Action.Created) + ",\"name\":\"signup\"},\"email\":\"matt@litmus.com\\\"\",\"id\":1,\"name\":\"Matthew Brindley\",\"plan\":{\"name\":\"Basic Trial 49\",\"price\":49,\"recurring\":31}}"));
        }
    }
}