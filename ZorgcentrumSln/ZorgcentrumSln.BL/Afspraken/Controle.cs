using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken;

public class Controle : Afspraak {
    public Controle(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId, AfspraakId referentieAfspraakId)
        : base(id, datumTijdStart, duurMin, afdelingId, patientId, artsId) {

        ReferentieAfspraakID = referentieAfspraakId;
    }

    public AfspraakId ReferentieAfspraakID { get; init; }
    //TODO: controle of referentie-afspraak tijdstip eerder is dan tijdstip van de controle-afspraak
    //TODO: De controle afspraak dient te gebeuren op dezelfde afdeling als de eerdere afpsraak en is voor dezelfde patient
    public static Result<Controle> Create(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId, AfspraakId referentieAfspraakId) {
        List<Error> errors = new();

        var createcommons = CreateCommons(id, datumTijdStart, duurMin, patientId, artsId, afdelingId);
        if (createcommons.IsFailure) {
            errors.AddRange(createcommons.Errors);
        }

        if (errors.Any()) {
            return Result<Controle>.Failure(errors);
        }
        return Result<Controle>.Succes(new Controle(id, datumTijdStart, duurMin, afdelingId, patientId, artsId, referentieAfspraakId));
    }
}
