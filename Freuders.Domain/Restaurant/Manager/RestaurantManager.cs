using Freuders.Domain.Restaurant.Client;

namespace Freuders.Domain.Restaurant.Manager;

public class RestaurantManager : IRestaurantManager
{
    private readonly IRestaurant _restaurant;

    public RestaurantManager(IEnumerable<Table.Table> tables) => _restaurant = new Restaurant(tables);

    public void OnArrive(Clients clients) => _restaurant.BookTable(new Table.Book.Request(clients));

    public void OnLeave(Clients clients) => _restaurant.LeaveTable(new Table.Leave.Request(clients));

    public Table.Table? Lookup(Clients clients) => _restaurant.LookupTable(new Table.Lookup.Request(clients)).Table;
}