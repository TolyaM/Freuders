using Freuders.Domain.Restaurant.Client;
using Freuders.Infrastructure.Contracts;

namespace Freuders.Domain.Restaurant.Leave;

public record Request(Clients Clients) : ICommand<Response>;