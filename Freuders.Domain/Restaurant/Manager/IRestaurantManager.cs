using Freuders.Domain.Restaurant.Client;

namespace Freuders.Domain.Restaurant.Manager;

public interface IRestaurantManager
{
    public void OnArrive(Clients group);

    public void OnLeave(Clients group);

    public Table.Table? Lookup(Clients group);
}