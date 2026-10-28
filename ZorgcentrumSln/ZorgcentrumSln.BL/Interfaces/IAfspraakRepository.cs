using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IAfspraakReposityReadOnly {
    Afspraak? GetById(AfspraakId id);

    IEnumerable<Afspraak> GetAll();
}

public interface IAfspraakRepository : IAfspraakReposityReadOnly {
    void Insert(Afspraak afspraak);
    void Update(Afspraak afspraak);
    void Delete(AfspraakId id);
}
