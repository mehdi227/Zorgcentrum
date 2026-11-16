using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces; 
public interface IAfspraakRepositoryReadOnly {
    Afspraak? GetById(AfspraakId id);
    IEnumerable<Afspraak?> GetAll();
}

public interface IAfspraakRepository : IAfspraakRepositoryReadOnly {
    public bool Insert(Afspraak? afspraak);
    public bool Update(Afspraak? afspraak);
    public bool Delete(AfspraakId? id);
}
