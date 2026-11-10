namespace Mizon.Database.Entities.Interfaces;

public interface IEntityTable<TId> : IEnitity
{
    public TId Id { get; set; }
}
