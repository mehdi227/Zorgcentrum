using ZorgcentrumSln.BL.AfdelingNamespace;

namespace ZorgcentrumSln.BL.ZorgcentrumNamespace; 
public class Zorgcentrum {
	private readonly HashSet<Afdeling> _afdelingen;

	public IReadOnlyCollection<Afdeling> Afdelingen => _afdelingen.AsReadOnly();
}
