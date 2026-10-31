using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.Results;

using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afdelingen;

public class Afdeling {
    public Afdeling(AfdelingId id, string naam, string code, string specialiteit) {
        Id = id;
        Naam = naam;
        Code = code;
        Specialiteit = specialiteit;
    }

    public AfdelingId Id { get; }
    public string Naam { get; }
    public string Code { get; init; }
    public string Specialiteit { get; init; }

    public static Result<Afdeling> Create(AfdelingId id,string naam,string code, string specialiteit) {
        List<Error> errors = new();

        var createAfdelingId = AfdelingId.Create(id.Value);
        if (createAfdelingId.IsFailure) {
            errors.AddRange(createAfdelingId.Errors);
        }

        if (string.IsNullOrWhiteSpace(naam)) {
            errors.Add(Error.Create("naam mag niet null of whitespace zijn."));
        }

        if (string.IsNullOrWhiteSpace(code)) {
            errors.Add(Error.Create("code mag niet null of whitespace zijn."));
        }

        if (string.IsNullOrWhiteSpace(specialiteit)) {
            errors.Add(Error.Create("specialiteit mag niet null of whitespace zijn."));
        }

        if (errors.Any()) {
            return Result<Afdeling>.Failure(errors);
        }

        return Result<Afdeling>.Succes(new Afdeling(id, naam, code, specialiteit));
    }

    private readonly HashSet<RijksRegisterNr> _ingeschrevenPatienten = new();
    public IReadOnlyCollection<RijksRegisterNr> IngeschrevenPatienten => _ingeschrevenPatienten.AsReadOnly();
    public Result RegistreerPatient(RijksRegisterNr rrn) {
        if (IngeschrevenPatienten.Contains(rrn)) {
            return Result.Failure(Error.Create("Arts is al ingeschreven."));
        }
        _ingeschrevenPatienten.Add(rrn);
        return Result.Succes();
    }

    private readonly HashSet<RizivNr> _ingeschrevenArtsen = new();
    public IReadOnlyCollection<RizivNr> IngeschrevenArtsen => _ingeschrevenArtsen.AsReadOnly();
    public Result RegistreerArts(RizivNr rizivNr) {
        if (IngeschrevenArtsen.Contains(rizivNr)) {
            return Result.Failure(Error.Create("Arts is al ingeschreven."));
        }
        _ingeschrevenArtsen.Add(rizivNr);
        return Result.Succes();
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
