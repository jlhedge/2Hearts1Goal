namespace _2Hearts1Goal.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public DateTimeOffset CreatedUtc { get; protected set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? LastUpdatedUtc { get; protected set; }

    protected void Touch()
    {
        LastUpdatedUtc = DateTimeOffset.UtcNow;
    }
}
