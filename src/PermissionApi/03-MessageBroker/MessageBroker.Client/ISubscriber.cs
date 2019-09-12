using System;
using System.Threading.Tasks;

namespace MessageBroker.Client
{
    public interface ISubscriber : IDisposable
    {
        /// <summary>
        /// Subscribe on topic
        /// </summary>
        /// <param name="topic">Topic on which subscription will be done</param>
        /// <param name="onReceived">Operation executed when message will be received</param>
        void SubscribeOnTopic(string topic, Action<string> onReceived);

        /// <summary>
        /// Subscribe on topic
        /// </summary>
        /// <param name="topic">Topic on which subscription will be done</param>
        /// <param name="onReceived">Operation executed when message will be received</param>
        Task SubscribeOnTopicAsynk(string topic, Action<string> onReceived);
    }
}