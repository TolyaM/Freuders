using Freuders.Domain.Restaurant.Client;
using Freuders.Infrastructure.Contracts;

namespace Freuders.Domain.Restaurant.Table.Leave;

public record Request(Clients Clients) : ICommand<Response>;