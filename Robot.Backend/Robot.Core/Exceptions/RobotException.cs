using System;
using System.Net;
using System.Runtime.Serialization;

namespace Robot.Core.Exceptions
{
    public class RobotException : Exception
    {
        public HttpStatusCode? HttpStatusCode { get; set; }

        protected RobotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RobotException(string message) : base(message)
        {
        }

        public RobotException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
