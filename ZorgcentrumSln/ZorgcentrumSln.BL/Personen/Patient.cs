using ZorgcentrumSln.Buildingblocks.ValueObjects;
using ZorgcentrumSln.BL.Afdelingen;

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
    //Create methode
    public static Patient Create(RijksRegisterNr rrn, string naam, string voornaam,DateOnly birthdate) {
        return new Patient(rrn, naam, voornaam, birthdate);
    }
}
