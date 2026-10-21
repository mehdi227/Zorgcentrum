using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Personen;

namespace ZorgcentrumSln.BL.Afdelingen;

public class Afdeling {
    public Afdeling() { }
    public string AfdelingId { get; init; }

    private readonly HashSet<Patient> _ingeschrevenPatienten = new();
    public IReadOnlyCollection<Patient> IngeschrevenPatienten => _ingeschrevenPatienten.AsReadOnly();
    public void SchrijfPatientIn(Patient patient) {
        _ingeschrevenPatienten.Add(patient);
    }

    private readonly HashSet<Arts> _ingeschrevenArtsen = new();
    public IReadOnlyCollection<Arts> IngeschrevenArtsen => _ingeschrevenArtsen.AsReadOnly();
    public void VerbindArtsMetAfdeling(Arts arts) {
        _ingeschrevenArtsen.Add(arts);
    }

    private readonly List<Afspraak> _afspraken = new();
    public IReadOnlyCollection<Afspraak> Afspraken => _afspraken.AsReadOnly();
    public void VoegAfspraakToe(Afspraak afspraak) {
        //TODO: de patient moet ingeschreven zijn op de afdeling
        //TODO: de arts moet verbonden zijn aan de afdeling
        //TODO: een patient mag maar een afspraak hebben bij dezelfde arts op dezelfde dag
        _afspraken.Add(afspraak);
    }
}
