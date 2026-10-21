using ZorgcentrumSln.BL.Afdelingen;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken {
    public class Consultatie : Afspraak {
        public Consultatie(AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, Afdeling afdeling, Patient patient, Arts arts) 
            : base(afspraakId, datumTijdStart, duurMin, afdeling, patient, arts) {
            if (duurMin! >= 10) 
                throw new Exception("een consultatie heeft een duurtijd van minstens 10 minuten.");
        }
    }
}
