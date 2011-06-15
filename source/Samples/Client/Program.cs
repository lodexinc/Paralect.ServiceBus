using System;
using Paralect.App;
using Paralect.ServiceBus;
using Paralect.ServiceBus.Dispatching;
using Shared.ServerMessages;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = ServiceBus.Run(c => c
                .SetUnityContainer(AppDomainUnityContext.Current)
                .MsmqTransport()
                .SetInputQueue("PSB.App1.Input")
                .SetErrorQueue("PSB.App1.Error")
                .AddEndpoint("Shared.ServerMessages", "PSB.App2.Input")
                .Dispatcher(d => d
                    .AddHandlers(typeof(Program).Assembly)
                )
            );

            Console.WriteLine("Client started. Press enter to send messages.");

            while (true)
            {
                Console.ReadKey();

                var message = new SayHelloToServerMessage() { Message = "Hello Server!" };
                bus.Send(message);
            }
        }
    }
}
