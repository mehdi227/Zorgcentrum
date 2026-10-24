using ZorgcentrumSln.Buildingblocks.ValueObjects;
using ZorgcentrumSln.BL.Afdelingen;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.BL.Personen;

public class Patient : Persoon {
    //constructor
    private Patient(RijksRegisterNr rrn, string naam, string voornaam,DateOnly birthdate)
        : base(rrn, naam, voornaam) {
        Birthdate = birthdate;
    }
    public DateOnly Birthdate {
        get; init;
    }
    
    public static Result<Patient> Create(RijksRegisterNr rrn, string naam, string voornaam,DateOnly birthdate) {
        //maak lege lijst van errors aan
        List<Error> errors = new();
        //vraag aan de persoon klasse of er fouten zijn voor de gemeenschappelijke properties
        var patientResult = Patient.GetValidationErrors(naam, voornaam, rrn);

        if (patientResult.IsFailure) {
            errors.AddRange(patientResult.Errors);
        }
        //als er fouten zijn kan er geen Patient aangemaakt worden.
        if (errors.Any()) {
            //geef lijst van fouten terug
            return Result<Patient>.Failure(errors);
        }
        return Result<Patient>.Succes(new Patient(rrn, naam, voornaam, birthdate));
    }
}
