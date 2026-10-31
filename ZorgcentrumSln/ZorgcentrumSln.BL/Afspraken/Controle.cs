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

}
