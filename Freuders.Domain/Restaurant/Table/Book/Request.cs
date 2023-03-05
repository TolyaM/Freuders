using Freuders.Domain.Restaurant.Client;
using Freuders.Infrastructure.Contracts;

namespace Freuders.Domain.Restaurant.Table.Book;

public record Request(Clients Clients) : ICommand<Response>;