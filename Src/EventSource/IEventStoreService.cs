using EventStore.ClientAPI;

namespace EventSource
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConection();
    }
}
