using System.Collections;
using System.Collections.Concurrent;
using Freuders.Domain.Restaurant.Client;

namespace Freuders.Domain.Restaurant.Table;

public class Tables : IEnumerable<Table>
{
    private readonly ConcurrentBag<Table> _tables;

    public Tables(IEnumerable<Table> tables) =>
        _tables = new ConcurrentBag<Table>(tables);

    public bool Exists(Clients clients) =>
        _tables.Any(table => table.Clients.ContainsKey(clients));

    public IEnumerable<Table> EmptyTables(int clientsCount) =>
        _tables.Where(table => table.IsEmpty() && table.NumberOfPlaces >= clientsCount);

    public IEnumerable<Table> SharedTables(int clientsCount) =>
        _tables
            .Where(table =>
                table.IncompleteLanding() &&
                table.NumberOfPlaces >= clientsCount &&
                table.NumberOfPlaces - table.Clients.Keys.Sum(client => client.Count) - clientsCount >= 0);

    public IEnumerator<Table> GetEnumerator() => _tables.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}