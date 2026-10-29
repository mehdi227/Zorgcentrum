using System.Globalization;
using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Personen;

public abstract class Persoon {
    protected Persoon(PersoonId id, RijksRegisterNr rrn, string naam, string voornaam, DateOnly birthdate) {
        PersoonId = id;
        Rrn = rrn;
        Naam = naam;
        Voornaam = voornaam;
        Birthdate = birthdate;
    }

    public PersoonId PersoonId { get; }

    public RijksRegisterNr Rrn { get; }
    public DateOnly Birthdate { get; init; }

    public string Naam { get; }

    public string Voornaam { get; }

    public override bool Equals(object? obj) {
        return Equals(obj as Persoon);
    }
    public bool Equals(Persoon? other) {
        return other is not null &&
            this.PersoonId == other.PersoonId; //vergelijk op basis van de identiteit
    }
    public static Result RrnBirthdateCorrelatieValid(RijksRegisterNr rrn, DateOnly birthdate) {
        string date = DateOnly.ParseExact(birthdate.ToString(), "yy-MM-dd", CultureInfo.InvariantCulture).ToString();
        string rrnDate = rrn.Value[..6];
        if (date == rrnDate) {
            return Result.Succes();
        } else return Result.Failure(new Error("RijksregisterNummer komt niet overeen met de geboortedatum"));
    }

    protected static Result<(String Naam, String Voornaam, RijksRegisterNr Rrn, PersoonId PersoonId, DateOnly birthdate)> GetValidationErrors(
        PersoonId id, string naam, string voornaam, RijksRegisterNr rrn, DateOnly birthdate) {
        //maak lege error lijst aan
        List<Error> errors = new();

        //controleer geldigheid attributen met basis types op NULL
        if (string.IsNullOrWhiteSpace(naam)) {
            errors.Add(Error.Create("Naam mag niet leeg zijn"));
        }
        //controleergeldigheid attributen die valueobjecten  of entities gebruiken met de create methode
        var createPersoonId = PersoonId.Create(PersoonId.CreateUnique().Value);

        if (createPersoonId.IsFailure) {
            errors.AddRange(createPersoonId.Errors);
        }

        var createRijksRegisterNummer = RijksRegisterNr.Create(rrn.Value);

        if (createRijksRegisterNummer.IsFailure) {
            errors.AddRange(createRijksRegisterNummer.Errors);
        }
        //controleer
        var rrnValid = Persoon.RrnBirthdateCorrelatieValid(rrn, birthdate);
        if (rrnValid.IsFailure) {
            errors.AddRange(rrnValid.Errors);
        }
        //als de error lijst niet leeg is dan return Result met errors
        if (errors.Any()) {
            return Result<(String Naam, String Voornaam, RijksRegisterNr Rrn, PersoonId PersoonId, DateOnly Birthdate)>.Failure(errors);
        }
        //alles is goed verlopen er zijn geen errors dus return Result met Object
        return Result<(String Naam, String Voornaam, RijksRegisterNr Rrn, PersoonId PersoonId,DateOnly Birthdate)>.Succes((naam, voornaam, createRijksRegisterNummer.Value!, createPersoonId.Value!,birthdate));
    }
}
