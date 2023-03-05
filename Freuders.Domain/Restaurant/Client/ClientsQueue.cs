using System.Collections;
using System.Collections.Concurrent;

namespace Freuders.Domain.Restaurant.Client;

public class ClientsQueue : IEnumerable<Clients>
{
    private readonly ConcurrentQueue<Clients> _clientsQueue = new();

    public void Add(Clients clients) => _clientsQueue.Enqueue(clients);

    public void Remove(Clients clients) => clients.Remove();

    public IEnumerator<Clients> GetEnumerator() => _clientsQueue
        .Where(client => !client.IsRemoved)
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}