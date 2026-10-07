using ZorgcentrumSln.BL.Domein.AfdelingNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Domein.PersoonNamespace; 
public class Arts : Persoon {
    public Arts(RijksRegisterNr rrn, string naam, string voornaam, string specialisatie, RizivNr rizivNr) 
		: base(rrn, naam, voornaam) {

    }

    private string _specialisatie;

	public string Specialisatie {
		get { return _specialisatie; }
		set { _specialisatie = value; }
	}

	private RizivNr _rizivNr;

    public RizivNr RizivNr {
		get { return _rizivNr; }
		set { _rizivNr = value; }
	}

}
