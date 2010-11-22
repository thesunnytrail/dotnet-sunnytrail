using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace SunnyTrail.Tests
{
    [TestFixture]
    public class EventActionFixture
    {
        [Test]
        public void ConvertToUnixTimestamp_WithValidDate_ShouldReturn()
        {
            Assert.That(EventAction.ConvertToUnixTimestamp(new DateTime(1970, 1, 1)), Is.EqualTo(0));
        }

        [Test]
        public void ConvertToUnixTimestamp_WithValidDate2_ShouldReturn()
        {
            Assert.That(EventAction.ConvertToUnixTimestamp(new DateTime(1970, 1, 2)), Is.EqualTo(86400d));
        }

        [Test]
        public void ConvertToUnixTimestamp_WithValidDate3_ShouldReturn()
        {
            Assert.That(EventAction.ConvertToUnixTimestamp(new DateTime(2010, 5, 3)), Is.EqualTo(1272844800d));
        }

        [Test]
        public void ConvertToUnixTimestamp_WithValidDateBefore1970_ShouldReturnNegativeNumber()
        {
            Assert.That(EventAction.ConvertToUnixTimestamp(new DateTime(1969, 1, 1)), Is.LessThan(0));
        }

        [Test]
        public void ConvertToDateTime_WithValidUnixTimestamp_ShouldReturn()
        {
            Assert.That(EventAction.ConvertToDateTime(1273823), Is.EqualTo(DateTime.Parse("1970-01-15 17:50:23.000")));
        }
    }
}