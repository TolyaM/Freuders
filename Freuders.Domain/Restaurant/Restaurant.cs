using Freuders.Domain.Restaurant.Client;
using Freuders.Domain.Restaurant.Table;

namespace Freuders.Domain.Restaurant;

public class Restaurant : IRestaurant
{
    private readonly Tables _tables;

    private readonly ClientsQueue _clientsQueue = new();

    public Restaurant(IEnumerable<Table.Table> tables) => _tables = new Tables(tables);

    public Table.Book.Response BookTable(Table.Book.Request request)
    {
        var response = new Table.Book.Command(_tables).Handle(request);

        if (response.Table is null)
        {
            _clientsQueue.Add(request.Clients);
        }

        return response;
    }

    public Table.Leave.Response LeaveTable(Table.Leave.Request request)
    {
        var response = new Table.Leave.Command(_tables).Handle(request);

        if (response.Table is null)
        {
            _clientsQueue.Remove(request.Clients);
        }
        else
        {
            foreach (var clients in _clientsQueue)
            {
                if(BoardingImpossible(response.Table!, clients.Count))
                {
                    continue;
                }

                if (response.Table.Clients.TryAdd(clients, default))
                {
                    _clientsQueue.Remove(clients);
                }
            }
        }

        return response;
    }

    public Table.Lookup.Response LookupTable(Table.Lookup.Request request) =>
        new Table.Lookup.Query(_tables).Handle(request);

    private static bool BoardingImpossible(
        Table.Table table,
        int clientsCount) =>
        table.NumberOfPlaces - table.Clients.Sum(client => client.Key.Count) < clientsCount;
}