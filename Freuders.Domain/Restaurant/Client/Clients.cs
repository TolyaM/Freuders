namespace Freuders.Domain.Restaurant.Client;

public class Clients : IEquatable<Clients>
{
    public Clients(int count) => Count = count;

    public Guid Id { get; } = Guid.NewGuid();

    public int Count { get; }

    public bool Equals(Clients? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id.Equals(other.Id) && Count == other.Count;
    }

    public override bool Equals(object? obj) => Equals(obj as Clients);

    public override int GetHashCode() => HashCode.Combine(Id, Count);
}