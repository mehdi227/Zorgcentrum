namespace ZorgcentrumSln.Buildingblocks.Results;

public record Error {
    public string Value { get; }

    public Error(string value) {
        Value = value;
    }
    
    public static Error Create(string value) {
        return new Error(value);
    }
}
