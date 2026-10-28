using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects; 
public sealed record AfspraakId {
    public Guid Value { get; }

    public AfspraakId(Guid value) {
        Value = value;
    }

    
    public static Result<AfspraakId> Create(Guid id) {
        if (id == Guid.Empty) {
            return Result<AfspraakId>.Failure(Error.Create("Het Afspraak ID mag niet leeg zijn."));
        }
        return Result<AfspraakId>.Succes(new AfspraakId(id));
    }

    public static AfspraakId CreateUnique() => new(Guid.NewGuid());
}
