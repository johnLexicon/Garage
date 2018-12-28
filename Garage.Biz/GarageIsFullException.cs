using System;
using System.Runtime.Serialization;

namespace Garage.Biz
{
    [Serializable]
    public class GarageIsFullException : Exception
    {
        public GarageIsFullException()
        {
        }

        public GarageIsFullException(string message) : base(message)
        {
        }

        public GarageIsFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GarageIsFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}