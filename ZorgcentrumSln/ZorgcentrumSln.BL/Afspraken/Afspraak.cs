using ZorgcentrumSln.BL.Afdelingen;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken;
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
        init;
    }

    private Arts _arts;

    public Arts Arts {
        get { return _arts; }
        init;
    }

    private Afdeling _afdeling;

    public Afdeling Afdeling {
        get { return _afdeling; }
        init { _afdeling = value; }
    }
    public static Result<(AfspraakId AfspraakId, DateTime DatumTijdStart, int DuurMin, Patient Patient, Arts Arts, Afdeling Afdeling)> GetValidationErrors(
        AfspraakId afspraakId, DateTime datumTijdStart, int duurMin, Patient patient, Arts arts, Afdeling afdeling) {
        //maak lege error lijst aan
        List<Error> errors = new();
        //controleer geldigheid attributen met basis types op NULL

        //controleergeldigheid attributen die valueobjecten of entities gebruiken met de create methode
        var createAfspraakId = AfspraakId.Create(afspraakId.Value);

        if (createAfspraakId.IsFailure) {
            errors.AddRange(createAfspraakId.Errors);
        }

        var createPatient = Patient.Create(patient.Rrn, patient.Naam, patient.Voornaam, patient.Birthdate);

        if (createPatient.IsFailure) {
            errors.AddRange(createPatient.Errors);
        }

        var createArts = Arts.Create(arts.Rrn, arts.Naam, arts.Voornaam, arts.Specialisatie, arts.RizivNr);

        if (createArts.IsFailure) {
            errors.AddRange(createArts.Errors);
        }

        var createAfdeling = Afdeling.Create();

        if () {

        }
        //als de error lijst niet leeg is dan return Result met errors
        if (errors.Any()) {
            return Result<(AfspraakId AfspraakId, DateTime DatumTijdStart, int DuurMin, Patient Patient, Arts Arts, Afdeling Afdeling)>.Failure(errors);
        }
    }

    public override bool Equals(object? obj) {
        return Equals(obj as Afspraak);
    }
    public bool Equals(Afspraak? other) {
        return other is not null &&
            this.AfspraakId == other.AfspraakId; //vergelijk op basis van de identiteit
    }

}
