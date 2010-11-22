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
    public class EventPlan
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "recurring")]
        public int Recurring { get; set; }
    }
}
