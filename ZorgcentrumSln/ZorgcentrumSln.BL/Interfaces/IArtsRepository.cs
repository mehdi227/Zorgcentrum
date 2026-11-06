using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IArtsReposityReadOnly {
    Arts? GetById(PersoonId id);

    IEnumerable<Arts> GetAll();
}

public interface IArtsRepository : IArtsReposityReadOnly {
    bool Insert(Arts arts);
    bool Update(Arts arts);
    bool Delete(PersoonId id);
}
