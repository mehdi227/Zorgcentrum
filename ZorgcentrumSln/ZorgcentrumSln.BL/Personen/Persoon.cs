using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Personen;

public abstract class Persoon {
    protected Persoon(PersoonId id, RijksRegisterNr rrn, string naam, string voornaam) {
        PersoonId = id;
        Rrn = rrn;
        Naam = naam;
        Voornaam = voornaam;
    }

    public PersoonId PersoonId { get; }

    public RijksRegisterNr Rrn { get; }

    public string Naam { get; }

    public string Voornaam { get; }

    public override bool Equals(object? obj) {
        return Equals(obj as Persoon);
    }
    public bool Equals(Persoon? other) {
        return other is not null &&
            this.PersoonId == other.PersoonId; //vergelijk op basis van de identiteit
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
            return Result<(String Naam, String Voornaam, RijksRegisterNr Rrn)>.Failure(errors);
        }
        //alles is goed verlopen er zijn geen errors dus return Result met Object
        return Result<(String Naam, String Voornaam, RijksRegisterNr Rrn)>.Succes((naam, voornaam, createRijksRegisterNummer.Value!));
    }
}
