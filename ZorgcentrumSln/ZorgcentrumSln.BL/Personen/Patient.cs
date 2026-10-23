using ZorgcentrumSln.Buildingblocks.ValueObjects;
using ZorgcentrumSln.BL.Afdelingen;

namespace ZorgcentrumSln.BL.Personen;

public class Patient : Persoon {
    //constructor
    private Patient(RijksRegisterNr rrn, string naam, string voornaam)
        : base(rrn, naam, voornaam) {

    }

    //Create methode
    public static Patient Create(RijksRegisterNr rrn, string naam, string voornaam) {
        return new Patient(rrn, naam, voornaam);
    }
}
