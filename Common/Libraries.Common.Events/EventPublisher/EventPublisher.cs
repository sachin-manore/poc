

namespace Libraries.Common.Event
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        protected readonly ILogger<EventPublisher> _Logging;
        public EventPublisher(ILogger<EventPublisher> logging, IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
            _Logging = logging;
        }

        /// <summary>
        /// Publish the event in the specific message broker.
        /// </summary>
        /// <typeparam name="T">The generic type of event which will publish in the message queue.</typeparam>
        /// <param name="event">Event that will publish in the message broker</param>
        public void PublishEvent<T>(T @event) where T : class
        {
            _Logging.LogInformation("PublishEvent execution started.", "MessageBroker", TraceLevel.Info);
            _publishEndpoint.Publish<T>(@event);
            _Logging.LogInformation("PublishEvent executed.", "MessageBroker", TraceLevel.Info);
        }
    }
}
