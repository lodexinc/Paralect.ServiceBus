using System;

namespace Paralect.ServiceBus
{
    public class ServiceBusMessage
    {
        public String SentFromComputerName { get; set; }
        public String SentFromQueueName { get; set; }
        public Object[] Messages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public ServiceBusMessage(params Object[] messages)
        {
            Messages = messages;
        }
    }
}





