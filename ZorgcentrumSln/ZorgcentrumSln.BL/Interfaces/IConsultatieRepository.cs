using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IConsultatieReposityReadOnly {
    Consultatie? GetById(AfspraakId id);

    IEnumerable<Consultatie> GetAll();
}

public interface IConsultatieRepository : IConsultatieReposityReadOnly {
    bool Insert(Consultatie afspraak);
    bool Update(Consultatie afspraak);
    bool Delete(AfspraakId id);
}
