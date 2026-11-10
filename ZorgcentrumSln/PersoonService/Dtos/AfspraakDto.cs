using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.ApplicationServicesProject.Dtos;

public record AfspraakDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId);
public record ConsultatieDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId) : AfspraakDto(id, datumTijdStart, duurMin, afdelingId, patientId, artsId);
public record OperatieDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId, string beschrijving) : AfspraakDto(id, datumTijdStart, duurMin, afdelingId, patientId, artsId);
public record ControleDto(AfspraakId id, DateTime datumTijdStart, int duurMin, AfdelingId afdelingId, PersoonId patientId, PersoonId artsId, AfspraakId referentieAfspraakId) : AfspraakDto(id, datumTijdStart, duurMin, afdelingId, patientId, artsId);
