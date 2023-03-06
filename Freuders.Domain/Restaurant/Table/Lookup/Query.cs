using Freuders.Infrastructure;

namespace Freuders.Domain.Restaurant.Table.Lookup;

public class Query : QueryExecutable<Request, Response>
{
    private readonly Tables _tables;

    public Query(Tables tables) => _tables = tables;

    protected override Response Execute(Request request)
    {
        var table = _tables.FirstOrDefault(table => table.Clients.Contains(request.Clients));

        return new Response(table);
    }
}