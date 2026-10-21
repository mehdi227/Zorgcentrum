using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afdelingen;
public class Afdeling {
	private readonly HashSet<Arts> _artsen;

	public IReadOnlyCollection<Arts> Artsen => _artsen.AsReadOnly();

	private readonly HashSet<Patient> _patienten;

	public IReadOnlyCollection<Patient> Patienten => _patienten.AsReadOnly();

	public void SchrijfPatientIn(RijksRegisterNr rrn) {
		// voeg patient toe aan lijst
	}
	public void ScrijfArtsIn(RizivNr rizivNr) {
		// TODO: zoek op basis van rizivNr
	}
	public bool IsArtsIngeschreven(Arts arts) {
		if (Artsen.Contains(arts)) {

		}
		return true;
	}
	public bool IsPatientIngeschreven(Patient patient) {
		if (Patienten.Contains(patient)) {

		}
		return true;
	}
	public void VoegAfspraakToe(AfspraakId afspraakId) {

	}
}
