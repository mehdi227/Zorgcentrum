using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces; 
public interface IOperatieRepositoryReadOnly {
    Operatie? GetById(AfspraakId id);

    IEnumerable<Operatie?> GetAll();
}
public interface IOperatieRepository {
    bool Insert(Operatie? operatie);
    bool Update(Operatie? operatie);
    bool Delete(AfspraakId id);
}
