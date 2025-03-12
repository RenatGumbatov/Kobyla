namespace Kobyla.inventory;

public abstract class Item(Game game)
{
    protected Game Game = game;
    public string Name { get; protected init; }
    public int Amount = 1;
    public bool RemoveOnUse { get; init; }

    public virtual void Use() {}

    public bool isRemoveOnUse() => RemoveOnUse;
    protected bool Equals(Item other)
    {
        return Game.Equals(other.Game);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Item)obj);
    }

    public override int GetHashCode()
    {
        return Game.GetHashCode();
    }
}