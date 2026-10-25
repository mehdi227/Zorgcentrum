using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects; 
public record AfspraakId {
    public AfspraakId(string value) {
        Value = value;
    }

    public string Value { get; }
    public static Result<AfspraakId> Create(string value) {
        if (string.IsNullOrWhiteSpace(value)) {
            return Result<AfspraakId>.Failure(Error.Create(""));
        }
        return Result<AfspraakId>.Succes(new AfspraakId(value));
    }
}
