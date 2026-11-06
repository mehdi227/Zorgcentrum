using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IPatientReposityReadOnly {
    Patient? GetById(PersoonId id);

    IEnumerable<Patient> GetAll();
}

public interface IPatientRepository : IPatientReposityReadOnly {
    bool Insert(Patient patient);
    bool Update(Patient patient);
    bool Delete(PersoonId id);
}

