using Freuders.Infrastructure;

namespace Freuders.Domain.Restaurant.Table.Leave;

public class Command : CommandExecutable<Request, Response>
{
    private readonly Tables _tables;

    public Command(Tables tables) => _tables = tables;

    protected override Response Execute(Request request)
    {
        var table = _tables.FirstOrDefault(table => table.Clients.Contains(request.Clients));

        table?.Clients.Remove(request.Clients);

        return new Response(table);
    }
}