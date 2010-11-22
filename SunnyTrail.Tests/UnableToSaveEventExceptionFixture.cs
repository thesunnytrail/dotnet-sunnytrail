using System.Net;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace SunnyTrail.Tests
{
    [TestFixture]
    public class UnableToSaveEventExceptionFixture
    {
        [Test]
        public void Ctor_WithValidParams_ShouldHaveCorrectMessage()
        {
            Assert.That(new UnableToSaveEventException("message", 403, "event_json", new WebException()).Message, Is.EqualTo("Unable to save the event described below. The server responded with: 403 message. The event to be sent was: event_json"));
        }
    }
}