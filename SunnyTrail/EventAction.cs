using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace SunnyTrail
{
    /// <summary>
    /// An event consists of basic data about a specific user and a pair of concepts (plan, action). Here's how a sample event looks like:
    ///{ 
    ///  'id': 1, 'name': 'customer name', 'email': 'customer email',
    ///  'action': { 
    ///  'name': 'signup',
    ///  'created': 1281876860
    ///  },
    ///  'plan': {
    ///  'name': 'Trial Plus 49',
    ///  'price': 0
    ///  }
    ///}
    /// </summary>
    [DataContract]
    public class EventAction
    {
        [DataMember(Name = "name")]
        private string Name
        {
            get
            {
                return Type.ToString("G").ToLower();
            }

            set
            {
                var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
                Type = (EventActionType)Enum.Parse(typeof(EventActionType), name);
            }
        }

        [IgnoreDataMember]
        public EventActionType Type { get; set; }

        [DataMember(Name = "created")]
        private double CreatedAt
        {
            get
            {
                return ConvertToUnixTimestamp(Created);
            }

            set
            {
                Created = ConvertToDateTime(value);
            }
        }

        [IgnoreDataMember]
        public DateTime Created { get; set; }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = date - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static DateTime ConvertToDateTime(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeStamp);
        }
    }
}