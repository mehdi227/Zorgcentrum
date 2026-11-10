using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.ApplicationServicesProject.Dtos;

public record PersoonDto(PersoonId id, RijksRegisterNr rrn, DateOnly birthdate, string naam, string voornaam);

public record ArtsDto(PersoonId id, RijksRegisterNr rrn, DateOnly birthdate, string naam, string voornaam, string specialisatie, RizivNr rizivNr) : PersoonDto(id, rrn, birthdate, naam, voornaam);
public record PatientDto(PersoonId id, RijksRegisterNr rrn, DateOnly birthdate, string naam, string voornaam) : PersoonDto(id,rrn,birthdate,naam,voornaam);
