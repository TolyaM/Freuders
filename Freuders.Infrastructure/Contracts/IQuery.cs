namespace Freuders.Infrastructure.Contracts;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}