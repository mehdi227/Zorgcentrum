using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken;

public class Operatie : Afspraak {
    public string Beschrijving { get; }

    public Operatie(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr, string beschrijving)
        : base(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr) {
        Beschrijving = beschrijving;
    }

    public static Result<Operatie> Create(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr, string beschrijving) {
        List<Error> errors = new();

        var createcommons = CreateCommons(id, datumTijdStart, duurMin, patientRrn, artsRizivNr, afdelingId);
        if (createcommons.IsFailure) {
            errors.AddRange(createcommons.Errors);
        }

        if (!(duurMin >= 10)) {
            errors.Add(Error.Create("een consultatie heeft een duurtijd van minstens 10 minuten."));
        }

        if (string.IsNullOrWhiteSpace(beschrijving)) {
            errors.Add(Error.Create("De beschrijving mag niet leeg zijn."));
        }

        if (errors.Any()) {
            return Result<Operatie>.Failure(errors);
        }

        return Result<Operatie>.Succes(new Operatie(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr, beschrijving));
    }
}
