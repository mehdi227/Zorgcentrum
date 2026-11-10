using ZorgcentrumSln.ApplicationServicesProject.Dtos;
using ZorgcentrumSln.BL.Personen;

namespace ZorgcentrumSln.ApplicationServicesProject.Factories {
    internal static class PersoonDtoFactory {
        public static PersoonDto CreatePersoonDto(Persoon p) {
            return p switch {
                Arts arts => new ArtsDto(
                     arts.Id,
                     arts.Rrn,
                     arts.Birthdate,
                     arts.Naam,
                     arts.Voornaam,
                     arts.Specialisatie,
                     arts.RizivNr),

                Patient patient => new PatientDto(
                        patient.Id,
                        patient.Rrn,
                        patient.Birthdate,
                        patient.Naam,
                        patient.Voornaam)
            };
        }
    }
}
