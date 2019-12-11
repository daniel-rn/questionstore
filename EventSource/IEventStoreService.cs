using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSource
{
    public interface IEventStoreService
    {
        IEventStoreConnection GetConection();
    }
}
