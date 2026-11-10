using ZorgcentrumSln.ApplicationServicesProject.Dtos;
using ZorgcentrumSln.BL.Afspraken;

namespace ZorgcentrumSln.ApplicationServicesProject.Factories {
    internal class AfspraakDtoFactory {
        public static AfspraakDto CreateAfspraakDto(Afspraak a) {
            return a switch {
                Consultatie consultatie => new ConsultatieDto(
                    consultatie.AfspraakID,
                    consultatie.DatumTijdStart,
                    consultatie.DuurMin,
                    consultatie.AfdelingID,
                    consultatie.PatientID,
                    consultatie.ArtsID),

                Operatie operatie => new OperatieDto(
                    operatie.AfspraakID,
                    operatie.DatumTijdStart,
                    operatie.DuurMin,
                    operatie.AfdelingID,
                    operatie.PatientID,
                    operatie.ArtsID,
                    operatie.Beschrijving),

                Controle controle => new ControleDto(
                    controle.AfspraakID,
                    controle.DatumTijdStart,
                    controle.DuurMin,
                    controle.AfdelingID,
                    controle.PatientID,
                    controle.ArtsID,
                    controle.ReferentieAfspraakID)

            };
        }
    }
}
