
namespace Libraries.Common.Event
{
    public abstract class EventConsumer<T> : IEventConsumer<T> where T : class
    {
        /// <summary>
        /// Consume the event from the message broker.
        /// </summary>
        /// <param name="context">consumer context which contain the event.</param>
        /// <returns>Task completed status</returns>
        public virtual async Task Consume(ConsumeContext<T> context)
        {
            
        }
    }
}
