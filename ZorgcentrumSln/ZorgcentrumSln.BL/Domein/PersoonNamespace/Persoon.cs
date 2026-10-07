using ZorgcentrumSln.BL.Domein.AfdelingNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Domein.PersoonNamespace; 
public abstract class Persoon {
    protected Persoon(RijksRegisterNr rrn, string naam, string voornaam) {
        Rrn = rrn;
        Naam = naam;
        Voornaam = voornaam;
    }

    private RijksRegisterNr _rrn;

	public RijksRegisterNr Rrn {
		get { return _rrn; }
		set { _rrn = value; }
	}

	private string _naam;

	public string Naam {
		get { return _naam; }
		set { _naam = value; }
	}

	private string _voornaam;

	public string Voornaam {
		get { return _voornaam; }
		set { _voornaam = value; }
	}

	private readonly HashSet<Afdeling> _afdelingen;

	public IReadOnlyCollection<Afdeling> Afdelingen => _afdelingen.AsReadOnly();
}
