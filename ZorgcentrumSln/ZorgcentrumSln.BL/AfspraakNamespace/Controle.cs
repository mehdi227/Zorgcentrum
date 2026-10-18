using ZorgcentrumSln.BL.AfdelingNamespace;
using ZorgcentrumSln.BL.PersoonNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.AfspraakNamespace;

public class Controle : Afspraak {
    public Controle(AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, Afdeling afdeling, Patient patient, Arts arts, Afspraak referentieAfspraak)
        : base(afspraakId, datumTijdStart, duurMin, afdeling, patient, arts) {
        if (referentieAfspraak.DatumTijdStart > datumTijdStart) {
            throw new Exception(
                "De tijdstip van de referentie-afspraak mag niet later zijn dan de tijdstip van de controle-afspraak.");
        }
        if (referentieAfspraak.Afdeling != afdeling) {
            throw new Exception(
                "De controle afspraak dient te gebeuren op dezelfde afdeling als de eerdere afspraak en voor dezelfde patiënt.");
        }
        ReferentieAfspraak = referentieAfspraak;
    }

    public Afspraak ReferentieAfspraak { get; init; }
    //TODO: controle of referentie-afspraak tijdstip eerder is dan tijdstip van de controle-afspraak
    //TODO: De controle afspraak dient te gebeuren op dezelfde afdeling als de eerdere afpsraak en is voor dezelfde patient

}
