using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken;
//TODO: maak van deze klasse een entiteit en gebruik aggregaat
public abstract class Afspraak {
    protected Afspraak(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr) {
        AfspraakID = id;
        DatumTijdStart = datumTijdStart;
        DuurMin = duurMin;
        AfdelingID = afdelingId;
        PatientRrn = patientRrn;
    }

    public AfspraakId AfspraakID { get; }

    public DateTime DatumTijdStart { get; }

    public int DuurMin { get; }

    public RijksRegisterNr PatientRrn { get; }

    public RizivNr artsRizivNr { get; }

    public AfdelingId AfdelingID { get; }

    public static Result<(AfspraakId AfspraakID, DateTime DatumTijdStart, int DuurMin, RijksRegisterNr PatientRrn, RizivNr ArtsRizivNr, AfdelingId AfdelingID)> CreateCommons(
        AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, RijksRegisterNr patientRrn, RizivNr artsRizivNr, AfdelingId afdelingId) {

        List<Error> errors = new();

        var createAfspraakId = AfspraakId.Create(afspraakId.Value);
        if (createAfspraakId.IsFailure) {
            errors.AddRange(createAfspraakId.Errors);
        }

        var createPatientId = RijksRegisterNr.Create(patientRrn.Value);
        if (createPatientId.IsFailure) {
            errors.AddRange(createPatientId.Errors);
        }

        var createArtsId = RizivNr.Create(artsRizivNr.Value);
        if (createArtsId.IsFailure) {
            errors.AddRange(createArtsId.Errors);
        }

        var createAfdelingId = AfdelingId.Create(afdelingId.Value);
        if (createAfdelingId.IsFailure) {
            errors.AddRange(createAfdelingId.Errors);
        }

        if (errors.Any()) {
            return Result<(AfspraakId AfspraakID, DateTime DatumTijdStart, int DuurMin, RijksRegisterNr PatientRrn, RizivNr ArtsRizivNr, AfdelingId AfdelingID)>.Failure(errors);
        }
        return Result<(AfspraakId AfspraakID, DateTime DatumTijdStart, int DuurMin, RijksRegisterNr PatientRrn, RizivNr ArtsRizivNr, AfdelingId AfdelingID)>.Succes((afspraakId, datumTijdStart, duurMin, patientRrn, artsRizivNr, afdelingId));
    }

    public override bool Equals(object? obj) {
        return Equals(obj as Afspraak);
    }
    public bool Equals(Afspraak? other) {
        return other is not null &&
            this.AfspraakID == other.AfspraakID; //vergelijk op basis van de identiteit
    }

}
