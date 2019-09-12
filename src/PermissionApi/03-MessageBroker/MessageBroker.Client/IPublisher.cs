using System;
using System.Threading.Tasks;

namespace MessageBroker.Client
{
    public interface IPublisher : IDisposable
    {
        /// <summary>
        /// Message will be published on topic
        /// </summary>
        /// <param name="topic">Name of topic on which message will be published</param>
        /// <param name="message">Message to publish</param>
        void PublishOnTopic(string topic, string message);

        /// <summary>
        /// Message will be published on topic
        /// </summary>
        /// <param name="topic">Name of topic on which message will be published</param>
        /// <param name="message">Message to publish</param>
        Task PublishOnTopicAsync(string topic, string message);
    }
}
