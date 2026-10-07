namespace ZorgcentrumSln.BL.Domein.AfspraakNamespace; 
public class Operatie : Afspraak {
	private string _beschrijving;

	public string Beschrijving {
		get { return _beschrijving; }
		set { _beschrijving = value; }
	}
}
