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

    public static Result IsCheckSumValid() {
        throw new NotImplementedException();
    }
    public static Result IsStructuurValid() {
        throw new NotImplementedException();
    }
}
