using System.Collections;

namespace Freuders.Domain.Restaurant.Client;

public class ClientsQueue : IEnumerable<Clients>
{
    private readonly LinkedList<Clients> _clientsQueue = new();

    public void Add(Clients clients) => _clientsQueue.AddLast(clients);

    public void Remove(Clients clients) => _clientsQueue.Remove(clients);

    public IEnumerator<Clients> GetEnumerator() => _clientsQueue.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}