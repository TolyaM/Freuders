using Freuders.Infrastructure.Contracts;

namespace Freuders.Infrastructure;

public abstract class QueryExecutable<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    public TResponse Handle(TRequest request) => Execute(request);

    protected abstract TResponse Execute(TRequest request);
}