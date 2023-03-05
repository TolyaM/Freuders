using System.Collections;

namespace Freuders.Domain.Restaurant.Table;

public class Tables : IEnumerable<Table>
{
    private readonly IReadOnlyCollection<Table> _tables;

    public Tables(IEnumerable<Table> tables) =>
        _tables = new List<Table>(tables);

    public IEnumerable<Table> EmptyTables(int clientsCount) =>
        _tables.Where(table => table.IsEmpty() && table.NumberOfPlaces >= clientsCount);

    public IEnumerable<Table> SharedTables(int clientsCount) =>
        _tables
            .Where(table =>
                table.IncompleteLanding() &&
                table.NumberOfPlaces >= clientsCount &&
                table.NumberOfPlaces - table.Clients.Sum(client => client.Count) - clientsCount >= 0);

    public IEnumerator<Table> GetEnumerator() => _tables.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}