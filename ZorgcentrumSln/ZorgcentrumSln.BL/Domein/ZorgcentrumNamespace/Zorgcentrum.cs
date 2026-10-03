using ZorgcentrumSln.BL.Domein.AfdelingNamespace;

namespace ZorgcentrumSln.BL.Domein.ZorgcentrumNamespace; 
public class Zorgcentrum {
	private HashSet<Afdeling> _afdelingen;

	public HashSet<Afdeling> Afdelingen {
		get { return _afdelingen; }
		set { _afdelingen = value; }
	}

}
