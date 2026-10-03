using ZorgcentrumSln.BL.Domein.AfdelingNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Domein.PersoonNamespace; 
public abstract class Persoon {
	private RijksRegisterNr _rrn;

	public RijksRegisterNr Rrn {
		get { return _rrn; }
		set { _rrn = value; }
	}

	private string _naam;

	public string Naam {
		get { return _naam; }
		set { _naam = value; }
	}

	private string _voornaam;

	public string Voornaam {
		get { return _voornaam; }
		set { _voornaam = value; }
	}

	private HashSet<Afdeling> _afdelingen;

	public HashSet<Afdeling> Afdeling {
		get { return _afdelingen; }
		set { _afdelingen = value; }
	}

}
