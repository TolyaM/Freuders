using Freuders.Domain.Restaurant.Client;
using Freuders.Infrastructure;

namespace Freuders.Domain.Restaurant.Table.Leave;

public class Command : CommandExecutable<Request, Response>
{
    private readonly Tables _tables;

    public Command(Tables tables) => _tables = tables;

    protected override Response Execute(Request request)
    {
        var table = _tables.FirstOrDefault(table => table.Clients.ContainsKey(request.Clients));

        table?.Clients.TryRemove(new KeyValuePair<Clients, byte>(request.Clients, default));

        return new Response(table);
    }
}