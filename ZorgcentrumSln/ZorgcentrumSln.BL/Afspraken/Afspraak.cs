using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken;
//TODO: maak van deze klasse een entiteit en gebruik aggregaat
public abstract class Afspraak {
    protected Afspraak(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId) {
        AfspraakID = id;
        DatumTijdStart = datumTijdStart;
        DuurMin = duurMin;
        AfdelingID = afdelingId;
        PatientID = patientId;
    }

    public AfspraakId AfspraakID { get; }

    public DateTime DatumTijdStart { get; }

    public int DuurMin { get; }

    public PersoonId PatientID { get; }

    public PersoonId ArtsID { get; }

    public AfdelingId AfdelingID { get; }

    public static Result<(AfspraakId AfspraakID, DateTime DatumTijdStart, int DuurMin, PersoonId PatientID, PersoonId ArtsID, AfdelingId AfdelingID)> CreateCommons(
        AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, PersoonId patientId, PersoonId artsId, AfdelingId afdelingId) {

        List<Error> errors = new();

        var createAfspraakId = AfspraakId.Create(afspraakId.Value);
        if (createAfspraakId.IsFailure) {
            errors.AddRange(createAfspraakId.Errors);
        }

        var createPatientId = PersoonId.Create(patientId.Value);
        if (createPatientId.IsFailure) {
            errors.AddRange(createPatientId.Errors);
        }

        var createArtsId = PersoonId.Create(artsId.Value);
        if (createArtsId.IsFailure) {
            errors.AddRange(createArtsId.Errors);
        }

        var createAfdelingId = AfdelingId.Create(afdelingId.Value);
        if (createAfdelingId.IsFailure) {
            errors.AddRange(createAfdelingId.Errors);
        }

        if (errors.Any()) {
            return Result<(AfspraakId AfspraakID, DateTime DatumTijdStart, int DuurMin, PersoonId PatientID, PersoonId ArtsID, AfdelingId AfdelingID)>.Failure(errors);
        }
        return Result<(AfspraakId AfspraakID, DateTime DatumTijdStart, int DuurMin, PersoonId PatientID, PersoonId ArtsID, AfdelingId AfdelingID)>.Succes((afspraakId, datumTijdStart, duurMin, patientId, artsId, afdelingId));
    }

    public override bool Equals(object? obj) {
        return Equals(obj as Afspraak);
    }
    public bool Equals(Afspraak? other) {
        return other is not null &&
            this.AfspraakID == other.AfspraakID; //vergelijk op basis van de identiteit
    }

}
