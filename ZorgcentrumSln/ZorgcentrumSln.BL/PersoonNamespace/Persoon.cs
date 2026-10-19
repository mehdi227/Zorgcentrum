using ZorgcentrumSln.BL.AfdelingNamespace;
using ZorgcentrumSln.BL.AfspraakNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.PersoonNamespace; 
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

    private readonly HashSet<Afdeling> _afdelingen;
    public IReadOnlyCollection<Afdeling> Afdelingen => _afdelingen.AsReadOnly();

    private readonly List<Afspraak> _afspraken = new();
    public IReadOnlyCollection<Afspraak> Afspraken => _afspraken.AsReadOnly();


    public void VoegAfspraakToe(Afspraak potentieleAfspraak) {
        foreach (Afspraak afspraakInLijst in Afspraken) {
            if (this is Patient) {
                if (potentieleAfspraak.Arts == afspraakInLijst.Arts &&
                potentieleAfspraak.DatumTijdStart.Day == afspraakInLijst.DatumTijdStart.Day)
                    throw new Exception("Een patient mag maar één afspraak bij dezelfde arts op dezelfde dag hebben.");
            }

            if (potentieleAfspraak is Operatie) {
                //duur 30min+
                if (potentieleAfspraak.DatumTijdStart.TimeOfDay >= afspraakInLijst.DatumTijdStart.TimeOfDay &&
                    potentieleAfspraak.DatumTijdStart.TimeOfDay <= afspraakInLijst.DatumTijdStart.AddMinutes(30).TimeOfDay) {
                    throw new Exception("Een afspraak kan niet overlappen met een andere afspraak");
                }
                _afspraken.Add(potentieleAfspraak);
            } else if (potentieleAfspraak is Consultatie) {
                //duur 10min+
                if (potentieleAfspraak.DatumTijdStart.TimeOfDay >= afspraakInLijst.DatumTijdStart.TimeOfDay &&
                    potentieleAfspraak.DatumTijdStart.TimeOfDay <= afspraakInLijst.DatumTijdStart.AddMinutes(10).TimeOfDay) {
                    throw new Exception("Een afspraak kan niet overlappen met een andere afspraak");
                }
                _afspraken.Add(potentieleAfspraak);
            }
        }
        _afspraken.Add(potentieleAfspraak);
    }
}
