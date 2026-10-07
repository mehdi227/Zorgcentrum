using ZorgcentrumSln.BL.Domein.AfdelingNamespace;

namespace ZorgcentrumSln.BL.Domein.ZorgcentrumNamespace; 
public class Zorgcentrum {
	private readonly HashSet<Afdeling> _afdelingen;

	public IReadOnlyCollection<Afdeling> Afdelingen => _afdelingen.AsReadOnly();
}
