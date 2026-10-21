using ZorgcentrumSln.BL.Afdelingen;

namespace ZorgcentrumSln.BL.Zorgcentrums; 
public class Zorgcentrum {
    public Zorgcentrum(){}

    private readonly HashSet<Afdeling> _afdelingen;
    public IReadOnlyCollection<Afdeling> Afdelingen => _afdelingen.AsReadOnly();
}
