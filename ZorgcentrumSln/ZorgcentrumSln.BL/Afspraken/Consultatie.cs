using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Afspraken {
    public class Consultatie : Afspraak {
        public Consultatie(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr)
            : base(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr) {

        }
        public static Result<Consultatie> Create(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr) {
            List<Error> errors = new();

            var createcommons = CreateCommons(id, datumTijdStart, duurMin, patientRrn, artsRizivNr, afdelingId);
            if (createcommons.IsFailure) {
                errors.AddRange(createcommons.Errors);
            }

            if (!(duurMin >= 10)) {
                errors.Add(Error.Create("een consultatie heeft een duurtijd van minstens 10 minuten."));
            }

            if (errors.Any()) {
                return Result<Consultatie>.Failure(errors);
            }
            return Result<Consultatie>.Succes(new Consultatie(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr));
        }
    }
}
