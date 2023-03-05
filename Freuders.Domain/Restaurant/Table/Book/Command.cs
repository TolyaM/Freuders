using Freuders.Infrastructure;

namespace Freuders.Domain.Restaurant.Table.Book;

public class Command : CommandExecutable<Request, Response>
{
    private readonly Tables _tables;

    public Command(Tables tables) => _tables = tables;

    protected override Response Execute(Request request)
    {
        var table = _tables
            .EmptyTables(request.Clients.Count)
            .MinBy(table => table.NumberOfPlaces);

        if (table is null)
        {
            table = _tables
                .SharedTables(request.Clients.Count)
                .MinBy(x =>
                    x.NumberOfPlaces -
                    x.Clients.Sum(client => client.Count) -
                    request.Clients.Count);
        }

        table?.Clients.Add(request.Clients);

        return new Response(table);
    }
}