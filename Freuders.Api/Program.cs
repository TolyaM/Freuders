using Freuders.Domain.Restaurant.Client;
using Freuders.Domain.Restaurant.Manager;
using Freuders.Domain.Restaurant.Table;

IRestaurantManager manager = new RestaurantManager(new []
{
    new Table(6),
    new Table(5),
    new Table(2),
    new Table(3),
});

var a = new Clients(5);
manager.OnArrive(a);

var b = new Clients(3);
manager.OnArrive(b);

var c = new Clients(2);
manager.OnArrive(c);

var e = new Clients(6);
manager.OnArrive(e);

var f = new Clients(5);
manager.OnArrive(f);

var g = new Clients(2);
manager.OnArrive(g);

var h = new Clients(3);
manager.OnArrive(h);

var j = new Clients(2);
manager.OnArrive(j);

manager.OnLeave(g);
manager.OnLeave(e);
manager.OnLeave(a);