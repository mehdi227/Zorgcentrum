using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.ApplicationServicesProject.Dtos;

public record AfspraakDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr);
public record ConsultatieDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr) : AfspraakDto(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr);
public record OperatieDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr, string beschrijving) : AfspraakDto(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr);
public record ControleDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, RijksRegisterNr patientRrn, RizivNr artsRizivNr, AfspraakId referentieAfspraakId) : AfspraakDto(id, datumTijdStart, duurMin, afdelingId, patientRrn, artsRizivNr);
