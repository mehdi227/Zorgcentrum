using ZorgcentrumSln.BL.Domein.PersoonNamespace;

namespace ZorgcentrumSln.BL.Domein.AfdelingNamespace; 
public class Afdeling {
	private HashSet<Arts> _artsen;

	public HashSet<Arts> Artsen {
		get { return _artsen; }
		set { _artsen = value; }
	}

	private HashSet<Patient> _patienten;

	public HashSet<Patient> Patienten {
		get { return _patienten; }
		set { _patienten = value; }
	}
}
