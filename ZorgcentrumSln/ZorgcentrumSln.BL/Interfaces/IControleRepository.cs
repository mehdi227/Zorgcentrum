using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IControleReposityReadOnly {
    Controle? GetById(AfspraakId id);

    IEnumerable<Controle?> GetAll();
}
public interface IControleRepository : IControleReposityReadOnly{
    bool Insert(Controle? controle);
    bool Update(Controle? controle);
    bool Delete(AfspraakId id);
}
