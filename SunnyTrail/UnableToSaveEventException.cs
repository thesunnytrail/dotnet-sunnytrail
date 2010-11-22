using System;
using System.Runtime.Serialization;

namespace SunnyTrail
{
    [Serializable]
    public class UnableToSaveEventException : Exception
    {
        public UnableToSaveEventException()
        {
        }

        public UnableToSaveEventException(string errorMessage, int statusCode, string eventJson, Exception inner)
            : base(string.Format("Unable to save the event described below. The server responded with: {0} {1}. The event to be sent was: {2}", statusCode, errorMessage, eventJson), inner)
        {
        }

        protected UnableToSaveEventException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}