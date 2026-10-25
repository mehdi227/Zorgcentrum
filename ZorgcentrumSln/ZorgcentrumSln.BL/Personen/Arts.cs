using ZorgcentrumSln.Buildingblocks.ValueObjects;
using ZorgcentrumSln.Buildingblocks.Results;

namespace ZorgcentrumSln.BL.Personen; 
public class Arts : Persoon {
    private Arts(RijksRegisterNr rrn, string naam, string voornaam, string specialisatie, RizivNr rizivNr) 
		: base(rrn, naam, voornaam) {
		_specialisatie = specialisatie;
		_rizivNr = rizivNr;
    }

    private string _specialisatie;
	public string Specialisatie {
		get { return _specialisatie; }
		init { _specialisatie = value; }
	}

	private RizivNr _rizivNr;
    public RizivNr RizivNr {
		get { return _rizivNr; }
		init { _rizivNr = value; }
	}

	public static Result<Arts> Create(RijksRegisterNr rrn, string naam, string voornaam, string specialisatie, RizivNr rizivNr) {
		//maak lege lijst aan
		List<Error> errors = new();
		//vraag aan de persoon klasse of er fouten zijn voor de gemeenschappelijke properties
		var artsResult = Arts.GetValidationErrors(naam,voornaam,rrn);

		if (artsResult.IsFailure) {
			errors.AddRange(artsResult.Errors);
		}

		if (errors.Any()) {
			return Result<Arts>.Failure(errors);
		}
        return Result<Arts>.Succes(new Arts(rrn,naam, voornaam, specialisatie, rizivNr));
	}
}
