using Freuders.Domain.Restaurant.Client;
using Freuders.Domain.Restaurant.Table.Leave;

namespace Freuders.Domain.Restaurant.Manager;

public class RestaurantManager : IRestaurantManager
{
    private readonly IRestaurant _restaurant;

    public RestaurantManager(IEnumerable<Table.Table> tables) => _restaurant = new Restaurant(tables);

    public void OnArrive(Clients clients) => _restaurant.BookTable(new Table.Book.Request(clients));

    public void OnLeave(Clients clients) => _restaurant.Leave(new Request(clients));

    public Table.Table? Lookup(Clients clients) => _restaurant.LookupTable(new Table.Lookup.Request(clients)).Table;
}