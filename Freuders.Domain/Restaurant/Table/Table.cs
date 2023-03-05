using Freuders.Domain.Restaurant.Client;

namespace Freuders.Domain.Restaurant.Table;

public class Table : IEquatable<Table>
{
    public Table(int numberOfPlaces) => NumberOfPlaces = numberOfPlaces;

    public Guid Number { get; } = Guid.NewGuid();

    public int NumberOfPlaces { get; }

    public readonly List<Clients> Clients = new();

    public bool IsEmpty() => Clients.Count == 0;

    public bool IncompleteLanding() => NumberOfPlaces - Clients.Count > 0;

    public bool Equals(Table? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Number.Equals(other.Number)
               && NumberOfPlaces == other.NumberOfPlaces
               && Clients.Equals(other.Clients);
    }

    public override bool Equals(object? obj) => Equals(obj as Table);

    public override int GetHashCode() => HashCode.Combine(Number, NumberOfPlaces, Clients);
}