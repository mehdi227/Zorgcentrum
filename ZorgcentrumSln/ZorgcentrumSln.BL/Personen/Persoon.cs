using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Personen;

public abstract class Persoon {
    protected Persoon(RijksRegisterNr rrn, string naam, string voornaam) {
        Rrn = rrn;
        Naam = naam;
        Voornaam = voornaam;
    }

    private RijksRegisterNr _rrn;

    public RijksRegisterNr Rrn {
        get { return _rrn; }
        init { _rrn = value; }
    }

    private string _naam;

    public string Naam {
        get { return _naam; }
        init { _naam = value; }
    }

    private string _voornaam;

    public string Voornaam {
        get { return _voornaam; }
        init { _voornaam = value; }
    }
    protected static Result<(RijksRegisterNr Rrn, String Naam, String Voornaam)> GetValidationErrors(
        RijksRegisterNr rrn, string naam, string voornaam) {

        List<Error> errors = new();

        var createRijksRegisterNummer = RijksRegisterNr.Create(rrn.Value);

        if (createRijksRegisterNummer.IsFailure) {
            errors.AddRange(createRijksRegisterNummer.Errors);
        }

        if (string.IsNullOrWhiteSpace(naam)) {
            errors.Add(Error.Create("Naam mag niet leeg zijn"));
        }

        if (errors.Any()) {
            return Result<(RijksRegisterNr Rrn, String Naam, String Voornaam)>.Failure(errors);
        }

        return Result<(RijksRegisterNr Rrn, String Naam, String Voornaam)>.Succes((createRijksRegisterNummer.Value!, naam, voornaam));

    }
}
