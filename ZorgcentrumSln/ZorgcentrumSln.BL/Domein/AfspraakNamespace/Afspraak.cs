using ZorgcentrumSln.BL.Domein.AfdelingNamespace;
using ZorgcentrumSln.BL.Domein.PersoonNamespace;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Domein.AfspraakNamespace;
//controleer het type afspraak door if(variable.GetType() == typeof(Consultatie))
public class Afspraak {
	private AfspraakId _afspraakId;

	public AfspraakId AfspraakId {
		get { return _afspraakId; }
		set { _afspraakId = value; }
	}

	private DateTime _datumTijdStart;

	public DateTime DatumTijdStart {
		get { return _datumTijdStart; }
		set { _datumTijdStart = value; }
	}

	private int _duurMin;

	public int DuurMin {
		get { return _duurMin; }
		set { _duurMin = value; }
	}

	private Patient _patient;

	public Patient Patient {
		get { return _patient; }
		set { _patient = value; }
	}

	private Arts _arts;

	public Arts Arts {
		get { return _arts; }
		set { _arts = value; }
	}

	private Afdeling _afdeling;

	public Afdeling Afdeling {
		get { return _afdeling; }
		set { _afdeling = value; }
	}
}
