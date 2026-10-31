using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects;

public class AfdelingId {
    public Guid Value { get; }

    public AfdelingId(Guid value) {
        Value = value;
    }

    public static Result<AfdelingId> Create(Guid id) {
        if (id == Guid.Empty) {
            return Result<AfdelingId>.Failure(Error.Create("Het afdeling ID mag niet leeg zijn."));
        }
        return Result<AfdelingId>.Succes(new AfdelingId(id));
    }
}
