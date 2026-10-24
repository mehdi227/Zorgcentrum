using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.Buildingblocks.ValueObjects; 
public record RijksRegisterNr {
    public string Value { get; set; }
    private RijksRegisterNr(string value) {
        Value = value;
    }
    public static Result<RijksRegisterNr> Create(string value) {
        if () {
            return Result<RijksRegisterNr>.Failure(Error.Create("Dit is geen geldig rijksregister nummer."));
        }
        return Result<RijksRegisterNr>.Succes(new RijksRegisterNr(value));
    }
    public bool IsCheckSumGeldig() {

    }
}
