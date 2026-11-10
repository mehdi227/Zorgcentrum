using ZorgcentrumSln.ApplicationServicesProject.Dtos;
using ZorgcentrumSln.ApplicationServicesProject.Factories;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.Results;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.ApplicationServicesProject.Services {
    public class AfspraakService {
        private IConsultatieRepository _consultatieRepository;
        private IOperatieRepository _operatieRepository;
        private IControleRepository _controleRepository;

        public AfspraakService(IConsultatieRepository consultatieRepo, IOperatieRepository operatieRepo, IControleRepository controleRepo) {
            _consultatieRepository = consultatieRepo;
            _operatieRepository = operatieRepo;
            _controleRepository = controleRepo;
        }
        public IReadOnlyCollection<AfspraakDto> GeefBeschikbareAfsprakenc() {
            IEnumerable<Consultatie> consultaties = _consultatieRepository.GetAll();
            IEnumerable<Operatie> operaties = _operatieRepository.GetAll();
            IEnumerable<Controle> controles = _controleRepository.GetAll();

            List<AfspraakDto> afspraakDtos = new();

            foreach (Afspraak a in consultaties) {
                afspraakDtos.Add(AfspraakDtoFactory.CreateAfspraakDto(a));
            }

            foreach (Afspraak a in operaties) {
                afspraakDtos.Add(AfspraakDtoFactory.CreateAfspraakDto(a));
            }

            foreach (Afspraak a in controles) {
                afspraakDtos.Add(AfspraakDtoFactory.CreateAfspraakDto(a));
            }

            return afspraakDtos;
        }
        public Result VerwijderConsultatie(AfspraakId id) {
            if (!_consultatieRepository.Delete(id)) {
                return Result.Failure(Error.Create("Afspraak id werd niet terug gevonden."));
            }

            return Result.Succes();
        }
        

    }
}
