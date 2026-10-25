using ZorgcentrumSln.BL.Afspraken;
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

    public override bool Equals(object? obj) {
        return Equals(obj as Persoon);
    }
    public bool Equals(Persoon? other) {
        return other is not null &&
            this.Rrn == other.Rrn; //vergelijk op basis van de identiteit
    }

    protected static Result<(String Naam, String Voornaam, RijksRegisterNr Rrn)> GetValidationErrors(
        string naam, string voornaam, RijksRegisterNr rrn) {
        //maak lege error lijst aan
        List<Error> errors = new();
        //controleer geldigheid attributen met basis types op NULL
        if (string.IsNullOrWhiteSpace(naam)) {
            errors.Add(Error.Create("Naam mag niet leeg zijn"));
        }
        //controleergeldigheid attributen die valueobjecten  of entities gebruiken met de create methode
        var createRijksRegisterNummer = RijksRegisterNr.Create(rrn.Value);

        if (createRijksRegisterNummer.IsFailure) {
            errors.AddRange(createRijksRegisterNummer.Errors);
        }
        //als de error lijst niet leeg is dan return Result met errors
        if (errors.Any()) {
            return Result<(String Naam, String Voornaam, RijksRegisterNr Rrn) >.Failure(errors);
        }
        //alles is goed verlopen er zijn geen errors dus return Result met Object
        return Result<(String Naam, String Voornaam, RijksRegisterNr Rrn)>.Succes((naam, voornaam, createRijksRegisterNummer.Value!));
    }
}
