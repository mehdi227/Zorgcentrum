namespace ZorgcentrumSln.Buildingblocks.Results;

public class Result {
    public bool IsSucces { get; }
    public bool IsFailure => !IsSucces;
    public IReadOnlyCollection<Error> Errors { get; }

    protected Result(bool isSucces, IReadOnlyCollection<Error> errors) {
        IsSucces = isSucces;
        Errors = errors;
    }

    public static Result Succes()
        => new(true, Array.Empty<Error>());

    public static Result Failure(IReadOnlyCollection<Error> errors)
        => new(false, errors);
    //vraag aan docent waarom 2de method Failure met 1 error instantie ipv lijst
    public static Result Failure(Error error)
        => Failure(new[] { error });
}

public class Result<T> : Result {
    private Result(bool isSucces,
        T? value,
        IReadOnlyCollection<Error> errors) : base(isSucces, errors) {
        Value = value;
    }
    public T? Value { get; }

    public static Result<T> Succes(T value) {
        return new Result<T>(true, value, Array.Empty<Error>());
    }
    public static Result<T> Failure(IEnumerable<Error> errors) {
        return new Result<T>(false, default, errors.ToList());
    }
    public static Result<T> Failure(Error error) {
        return Failure(new[] { error });
    }
}