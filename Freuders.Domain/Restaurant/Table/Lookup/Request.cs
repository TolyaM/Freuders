using Freuders.Domain.Restaurant.Client;
using Freuders.Infrastructure.Contracts;

namespace Freuders.Domain.Restaurant.Table.Lookup;

public record Request(Clients Clients) : IQuery<Response>;