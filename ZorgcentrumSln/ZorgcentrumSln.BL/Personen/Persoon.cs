using ZorgcentrumSln.BL.Afdelingen;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Personen; 
public abstract class Persoon {
    protected Persoon(RijksRegisterNr rrn, string naam, string voornaam) {
        Rrn = rrn;
        Naam = naam;
        Voornaam = voornaam;
    }

    private RijksRegisterNr _rrn;

	public RijksRegisterNr Rrn {
		get { return _rrn; }
		init { _rrn = value; }
	}

	private string _naam;

	public string Naam {
		get { return _naam; }
		init { _naam = value; }
	}

	private string _voornaam;

	public string Voornaam {
		get { return _voornaam; }
		init { _voornaam = value; }
	}
}
