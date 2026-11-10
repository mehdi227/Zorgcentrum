using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects; 
public record RizivNr {
    private RizivNr(string value) {
        Value = value;
    }

    public string Value { get; }
    public static Result<RizivNr> Create(string value) {
        return Result<RizivNr>.Succes(new RizivNr(value));
    }
}
