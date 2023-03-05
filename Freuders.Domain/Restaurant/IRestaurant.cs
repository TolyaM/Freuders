using Freuders.Domain.Restaurant.Table.Leave;

namespace Freuders.Domain.Restaurant;

public interface IRestaurant
{
    public Table.Book.Response BookTable(Table.Book.Request request);

    public Response Leave(Request request);

    public Table.Lookup.Response LookupTable(Table.Lookup.Request request);
}