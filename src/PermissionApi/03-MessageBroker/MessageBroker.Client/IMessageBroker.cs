using System;

namespace MessageBroker.Client
{
    public interface IMessageBroker : IDisposable
    {
        /// <summary>
        /// To publish new message
        /// </summary>
        IPublisher Publisher { get; }

        /// <summary>
        /// To subscribe on topic
        /// </summary>
        ISubscriber Subscriber { get; }
    }
}
