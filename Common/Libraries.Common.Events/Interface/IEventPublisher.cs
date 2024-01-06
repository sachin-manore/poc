
namespace Libraries.Common.Event
{
    public interface IEventPublisher
    {
        /// <summary>
        /// Publish the event in the specific message broker.
        /// </summary>
        /// <typeparam name="T">The generic type of event which will publish in the message queue</typeparam>
        /// <param name="event">Event that will publish in the message broker</param>
        void PublishEvent<T>(T @event) where T : class;
    }
}
