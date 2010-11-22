using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

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
    public class Event
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "action")]
        public EventAction Action { get; set; }
        [DataMember(Name = "plan")]
        public EventPlan Plan { get; set; }

        /// <summary>
        /// Converts this event into a json string
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            using (var memoryStream = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof (Event)).WriteObject(memoryStream, this);
                memoryStream.Position = 0;
                using (var reader = new StreamReader(memoryStream))
                    return reader.ReadToEnd();
            }
        }


    }
}