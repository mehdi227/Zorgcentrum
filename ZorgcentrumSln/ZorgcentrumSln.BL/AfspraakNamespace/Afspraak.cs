using ZorgcentrumSln.BL.AfdelingNamespace;
using ZorgcentrumSln.BL.PersoonNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.AfspraakNamespace;
//controleer het type afspraak door if(variable.GetType() == typeof(Consultatie))
//TODO: maak van deze klasse een entiteit en gebruik aggregaat
public abstract class Afspraak {
    protected Afspraak(AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, Afdeling afdeling, Patient patient, Arts arts) {
        AfspraakId = afspraakId;
        DatumTijdStart = datumTijdStart;
        DuurMin = duurMin;
        Afdeling = afdeling;
        Patient = patient;
    }

    public AfspraakId AfspraakId {
        get;
    }

    public override bool Equals(object? obj) {
        return Equals(obj as Afspraak);
    }
    public bool Equals(Afspraak? other) {
        return other is not null &&
            this.AfspraakId == other.AfspraakId; //vergelijk op basis van de identiteit
    }

    private DateTime _datumTijdStart;

    public DateTime DatumTijdStart {
        get { return _datumTijdStart; }
        init { _datumTijdStart = value; }
    }

    private int _duurMin;

    public int DuurMin {
        get { return _duurMin; }
        init { _duurMin = value; }
    }

    private Patient _patient;

    public Patient Patient {
        get { return _patient; }
        init {
            if (!Patient.Afdelingen.Contains(Afdeling)) throw 
                    new Exception("De patient moet ingeschreven zijn op de afdeling van de afspraak.");
            _patient = value;
        }
    }

    private Arts _arts;

    public Arts Arts {
        get { return _arts; }
        init {
            if (!Arts.Afdelingen.Contains(Afdeling)) throw 
                    new Exception("De arts moet verbonden zijn aan de afdeling van de afspraak.");
            _arts = value;
        }
    }

    private Afdeling _afdeling;

    public Afdeling Afdeling {
        get { return _afdeling; }
        init { _afdeling = value; }
    }
}
