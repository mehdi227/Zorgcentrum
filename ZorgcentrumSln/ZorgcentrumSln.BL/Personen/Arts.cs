using ZorgcentrumSln.Buildingblocks.ValueObjects;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.BL.Personen;

public class Arts : Persoon {

    private string _specialisatie;
    public string Specialisatie {
        get { return _specialisatie; }
        init { _specialisatie = value; }
    }

    private RizivNr _rizivNr;
    public RizivNr RizivNr {
        get { return _rizivNr; }
        init { _rizivNr = value; }
    }

    private Arts(PersoonId id, RijksRegisterNr rrn, string naam, string voornaam, DateOnly birthdate, string specialisatie, RizivNr rizivNr)
        : base(id, rrn, naam, voornaam, birthdate) {
        _specialisatie = specialisatie;
        _rizivNr = rizivNr;
    }

    public static Result<Arts> Create(PersoonId id, RijksRegisterNr rrn, string naam, string voornaam, DateOnly birthdate, string specialisatie, RizivNr rizivNr) {
        //maak lege lijst aan
        List<Error> errors = new();
        //vraag aan de persoon klasse of er fouten zijn voor de gemeenschappelijke properties
        var artsResult = Arts.GetValidationErrors(id, naam, voornaam, rrn, birthdate);

        if (artsResult.IsFailure) {
            errors.AddRange(artsResult.Errors);
        }

        if (errors.Any()) {
            return Result<Arts>.Failure(errors);
        }
        return Result<Arts>.Succes(new Arts(id, rrn, naam, voornaam, birthdate, specialisatie, rizivNr));
    }
}
