using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.Results;

using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afdelingen;

public class Afdeling {
    public Afdeling() { }
    public static Result<Afdeling> Create() {

    }
    public string Code { get; init; }
    public string Specialiteit { get; init; }

    private readonly HashSet<RijksRegisterNr> _ingeschrevenPatienten = new();
    public IReadOnlyCollection<RijksRegisterNr> IngeschrevenPatienten => _ingeschrevenPatienten.AsReadOnly();
    public void RegistreerPatient(RijksRegisterNr rrn) {
        _ingeschrevenPatienten.Add(rrn);
    }

    private readonly HashSet<RizivNr> _ingeschrevenArtsen = new();
    public IReadOnlyCollection<RizivNr> IngeschrevenArtsen => _ingeschrevenArtsen.AsReadOnly();
    public void RegistreerArts(RizivNr rizivNr) {
        _ingeschrevenArtsen.Add(rizivNr);
    }

    private readonly List<Afspraak> _afspraken = new();
    public IReadOnlyCollection<Afspraak> Afspraken => _afspraken.AsReadOnly();
    public Result VoegAfspraakToe(Afspraak afspraak) {
        List<Error> errors = new();
        if (!IngeschrevenArtsen.Contains(afspraak.Arts.RizivNr)) {
            errors.Add(new Error("De arts verbonden met deze afspraak is niet ingeschreven op deze afdeling."));
        }
        if (!IngeschrevenPatienten.Contains(afspraak.Patient.Rrn)) {
            errors.Add(new Error("De patient verbonden met deze afspraak is niet ingeschreven op deze afdeling."));
        }
        if (Afspraken.Any(a =>
            a.Patient.Rrn == afspraak.Patient.Rrn &&
            a.Arts.RizivNr == afspraak.Arts.RizivNr &&
            a.DatumTijdStart.Day == afspraak.DatumTijdStart.Day)) {
            errors.Add(new Error("Deze afpraak zou overlappen met een bestaande afspraak."));
        }
        if (errors.Any()) {
            return Result.Failure(errors);
        } else {
            _afspraken.Add(afspraak);
            return Result.Succes();
        }
    }
}
