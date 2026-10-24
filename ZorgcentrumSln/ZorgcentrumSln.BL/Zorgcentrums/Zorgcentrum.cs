using ZorgcentrumSln.BL.Afdelingen;

namespace ZorgcentrumSln.BL.Zorgcentrums; 
public class Zorgcentrum {
    public Zorgcentrum(){}
    public int ID { get; }
    public string Naam {  get; set; }
    private readonly HashSet<Afdeling> _afdelingen;
    public IReadOnlyCollection<Afdeling> Afdelingen => _afdelingen.AsReadOnly();
    public void VoegafdelingToe() {

    }
}
