using Freuders.Domain.Restaurant.Client;
using Freuders.Domain.Restaurant.Table;

namespace Freuders.Domain.Restaurant;

public class Restaurant : IRestaurant
{
    private readonly object _lockerBook = new();
    private readonly object _lockerLeave = new();

    private readonly Tables _tables;
    private readonly ClientsQueue _clientsQueue = new();

    public Restaurant(IEnumerable<Table.Table> tables) => _tables = new Tables(tables);

    public Table.Book.Response BookTable(Table.Book.Request request)
    {
        lock (_lockerBook)
        {
            var response = new Table.Book.Command(_tables).Handle(request);

            if (response.Table is null)
            {
                _clientsQueue.Add(request.Clients);
            }

            return response;
        }
    }

    public Table.Leave.Response Leave(Table.Leave.Request request)
    {
        lock (_lockerLeave)
        {
            var response = new Table.Leave.Command(_tables).Handle(request);

            if (response.Table is null)
            {
                _clientsQueue.Remove(request.Clients);
            }
            else
            {
                var clientsToRemove = new List<Clients>();
                foreach (var clients in _clientsQueue)
                {
                    if(BoardingImpossible(response.Table!, clients.Count))
                    {
                        continue;
                    }

                    response.Table.Clients.Add(clients);
                    clientsToRemove.Add(clients);
                }

                foreach (var clients in clientsToRemove)
                {
                    _clientsQueue.Remove(clients);
                }
            }

            return response;
        }
    }

    public Table.Lookup.Response LookupTable(Table.Lookup.Request request) =>
        new Table.Lookup.Query(_tables).Handle(request);

    private static bool BoardingImpossible(
        Table.Table table,
        int clientsCount) =>
        table.NumberOfPlaces - table.Clients.Sum(client => client.Count) < clientsCount;
}