using System.Security.Cryptography.X509Certificates;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.BL.Afdelingen;

public class Afdeling {
    public Afdeling() { }
    public string AfdelingId { get; init; }

    private readonly HashSet<Patient> _ingeschrevenPatienten = new();
    public IReadOnlyCollection<Patient> IngeschrevenPatienten => _ingeschrevenPatienten.AsReadOnly();
    public void RegistreerPatient(Patient patient) {
        _ingeschrevenPatienten.Add(patient);
    }

    private readonly HashSet<Arts> _ingeschrevenArtsen = new();
    public IReadOnlyCollection<Arts> IngeschrevenArtsen => _ingeschrevenArtsen.AsReadOnly();
    public void RegistreerArts(Arts arts) {
        _ingeschrevenArtsen.Add(arts);
    }

    private readonly List<Afspraak> _afspraken = new();
    public IReadOnlyCollection<Afspraak> Afspraken => _afspraken.AsReadOnly();
    public void VoegAfspraakToe(Result<Afspraak> afspraak) {
        //TODO: de patient moet ingeschreven zijn op de afdeling
        //TODO: de arts moet verbonden zijn aan de afdeling
        if (IngeschrevenPatienten.Contains(afspraak.Value.Patient) && 
            IngeschrevenArtsen.Contains(afspraak.Value.Arts)) {
            bool bestaatAl = Afspraken.Any(a =>
            a.Patient.Rrn == afspraak.Value.Patient.Rrn &&
            a.Arts.RizivNr == afspraak.Value.Arts.RizivNr &&
            a.DatumTijdStart.Day == afspraak.Value.DatumTijdStart.Day
            );
            if (!bestaatAl) {
                _afspraken.Add(afspraak.Value);
            } else {
                //implementeer result
            }
            
        } else {
            //implementeer Result
        }
    }
}
