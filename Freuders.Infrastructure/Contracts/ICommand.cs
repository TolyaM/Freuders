namespace Freuders.Infrastructure.Contracts;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}