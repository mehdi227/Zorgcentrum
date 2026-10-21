using ZorgcentrumSln.BL.Afdelingen;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken; 
public class Operatie : Afspraak {
    public Operatie(AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, Afdeling afdeling, Patient patient, Arts arts, string beschrijving)
        : base(afspraakId, datumTijdStart, duurMin, afdeling, patient, arts) {
        if (duurMin! >= 30)
            throw new Exception("De tijdstip van een operatie moet minstens 30 minuten zijn.");
        if (string.IsNullOrWhiteSpace(beschrijving))
            throw new Exception("Beschrijving mag niet leeg zijn");
        Beschrijving = beschrijving;
    }

    private string _beschrijving;
    public string Beschrijving {
		get { return _beschrijving; }
        init;
	}
}
