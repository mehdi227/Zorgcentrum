using ZorgcentrumSln.BL.Domein.PersoonNamespace;

namespace ZorgcentrumSln.BL.Domein.AfdelingNamespace; 
public class Afdeling {
	private readonly HashSet<Arts> _artsen;

	public IReadOnlyCollection<Arts> Artsen => _artsen.AsReadOnly();

	private readonly HashSet<Patient> _patienten;

	public IReadOnlyCollection<Patient> Patienten => _patienten.AsReadOnly(); 
}
