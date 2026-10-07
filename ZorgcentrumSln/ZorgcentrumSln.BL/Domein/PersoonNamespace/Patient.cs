using ZorgcentrumSln.BL.Domein.AfdelingNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Domein.PersoonNamespace;

public class Patient : Persoon {
    public Patient(RijksRegisterNr rrn, string naam, string voornaam) 
        : base(rrn, naam, voornaam) {

    }

    public static void Create() {

    }
}
