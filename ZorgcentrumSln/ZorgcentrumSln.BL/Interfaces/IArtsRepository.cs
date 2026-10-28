using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IArtsReposityReadOnly {
    Arts? GetById(RijksRegisterNr rrn);

    IEnumerable<Arts> GetAll();
}

public interface IArtsRepository : IArtsReposityReadOnly {
    void Insert(Arts arts);
    void Update(Arts arts);
    void Delete(RijksRegisterNr rrn);
}
