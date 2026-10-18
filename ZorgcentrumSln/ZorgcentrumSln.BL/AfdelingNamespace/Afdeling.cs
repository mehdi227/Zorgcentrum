using ZorgcentrumSln.BL.PersoonNamespace;

namespace ZorgcentrumSln.BL.AfdelingNamespace;
public class Afdeling {
	private readonly HashSet<Arts> _artsen;

	public IReadOnlyCollection<Arts> Artsen => _artsen.AsReadOnly();

	private readonly HashSet<Patient> _patienten;

	public IReadOnlyCollection<Patient> Patienten => _patienten.AsReadOnly();

	public void SchrijfPatientIn() {
		// voeg patient toe aan lijst
	}
	public void ScrijfArtsIn() {
		// voeg arts toe aan lijst
	}
	public bool IsArtsIngeschreven(Arts arts) {
		return true;
	}
	public bool IsPatientIngeschreven(Patient patient) {
		return true;
	}
}
