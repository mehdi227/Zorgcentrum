using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.BL.Interfaces;

public interface IPatientReposityReadOnly {
    Patient? GetById(RijksRegisterNr rrn);

    IEnumerable<Patient> GetAll();
}

public interface IPatientRepository : IPatientReposityReadOnly {
    void Insert(Patient patient);
    void Update(Patient patient);
    void Delete(RijksRegisterNr rrn);
}

