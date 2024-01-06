

namespace Libraries.Common.Event
{
    public interface IEventConsumer<T>  : IConsumer<T> where T : class
    {
    }
}
