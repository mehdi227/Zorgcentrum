using ZorgcentrumSln.BL.AfspraakNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.PersoonNamespace; 
public class Arts : Persoon {
    private Arts(RijksRegisterNr rrn, string naam, string voornaam, string specialisatie, RizivNr rizivNr) 
		: base(rrn, naam, voornaam) {
		_specialisatie = specialisatie;
		_rizivNr = rizivNr;
    }

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

	public static Arts Create(RijksRegisterNr rrn, string naam, string voornaam, string specialisatie, RizivNr rizivNr) {
		return new Arts(rrn, naam, voornaam, specialisatie, rizivNr);
	}
}
