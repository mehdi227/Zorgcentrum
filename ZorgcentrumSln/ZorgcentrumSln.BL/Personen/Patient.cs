using ZorgcentrumSln.Buildingblocks.ValueObjects;
using ZorgcentrumSln.BL.Afdelingen;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.BL.Personen;

public class Patient : Persoon {
    //constructor
    private Patient(PersoonId id, RijksRegisterNr rrn, string naam, string voornaam, DateOnly birthdate)
        : base(id, rrn, naam, voornaam) {
        Birthdate = birthdate;
    }
    public DateOnly Birthdate {
        get; init;
    }

    public static Result<Patient> Create(PersoonId id, RijksRegisterNr rrn, string naam, string voornaam, DateOnly birthdate) {
        //maak lege lijst van errors aan
        List<Error> errors = new();
        //vraag aan de persoon klasse of er fouten zijn voor de gemeenschappelijke properties
        var patientResult = Patient.GetValidationErrors(id, naam, voornaam, rrn);

        if (patientResult.IsFailure) {
            errors.AddRange(patientResult.Errors);
        }
        //als er fouten zijn kan er geen Patient aangemaakt worden.
        if (errors.Any()) {
            //geef lijst van fouten terug
            return Result<Patient>.Failure(errors);
        }
        return Result<Patient>.Succes(new Patient(id, rrn, naam, voornaam, birthdate));
    }
}
