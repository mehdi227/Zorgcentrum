using ZorgcentrumSln.ApplicationServicesProject.Dtos;
using ZorgcentrumSln.ApplicationServicesProject.Factories;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.ApplicationServicesProject.Services {
    public class AfspraakService {
        private IAfspraakRepository _afspraakRepository;
        

        public AfspraakService(IAfspraakRepository afspraakRepository) {
            _afspraakRepository = afspraakRepository;
        }
        public IReadOnlyCollection<AfspraakDto> GeefBeschikbareAfsprakenc() {
            IEnumerable<Afspraak> afspraken = _afspraakRepository.GetAll();

            List<AfspraakDto> afspraakDtos = new();

            foreach (Afspraak a in afspraken) {
                afspraakDtos.Add(AfspraakDtoFactory.CreateAfspraakDto(a));
            }

            return afspraakDtos;
        }
        public Result VerwijderAfspraak(AfspraakId id) {
            if (!_afspraakRepository.Delete(id)) {
                return Result.Failure(Error.Create("Afspraak id werd niet terug gevonden."));
            }

            return Result.Succes();
        }

        public Result<AfspraakDto> VoegAfspraakToe(Afspraak newAfspraak) {
            bool result = _afspraakRepository.Insert(newAfspraak);

            if (!result) {
                return Result<AfspraakDto>.Failure(Error.Create("De insert kon niet worden uitgevoerd"));
            }

            return Result<AfspraakDto>.Succes(AfspraakDtoFactory.CreateAfspraakDto(newAfspraak));
        }
    }
}
