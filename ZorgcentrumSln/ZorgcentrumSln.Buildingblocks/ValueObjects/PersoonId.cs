using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects;

public sealed record PersoonId {
    public Guid Value;

    private PersoonId(Guid id) {
        Value = id;
    }

    public static Result<PersoonId> Create(Guid id) {
        if (id == Guid.Empty) {
            return Result<PersoonId>.Failure(Error.Create("Het persoon ID mag niet leeg zijn."));
        }

        return Result<PersoonId>.Succes(new PersoonId(id));
    }

    public static PersoonId CreateUnique() => new(Guid.NewGuid());
}
