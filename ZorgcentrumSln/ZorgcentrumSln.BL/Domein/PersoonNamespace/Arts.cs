using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Domein.PersoonNamespace; 
public class Arts {
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
