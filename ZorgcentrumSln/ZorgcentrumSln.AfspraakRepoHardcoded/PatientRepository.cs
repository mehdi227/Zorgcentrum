using System.Globalization;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded;

public class PatientRepository : IPatientRepository {
    private HashSet<Patient> _patienten = new() {
        Patient.Create(
            PersoonId.CreateUnique(),
            RijksRegisterNr.Create("85073003328").Value!,
            "zirar",
            "mehdi",
            new DateOnly(2003, 1, 31)
            ).Value!,
        Patient.Create(
            PersoonId.CreateUnique(),
            RijksRegisterNr.Create("95062756789").Value!,
            "willems",
            "noah",
            new DateOnly(1995, 6, 27)
            ).Value!,
        Patient.Create(
            PersoonId.CreateUnique(),
            RijksRegisterNr.Create("88110645678").Value!,
            "maes",
            "emma",
            new DateOnly(1988, 11, 6)
            ).Value!,
        Patient.Create(
            PersoonId.CreateUnique(),
            RijksRegisterNr.Create("02041234567").Value!,
            "dubois",
            "lucas",
            new DateOnly(2002, 4, 12)
            ).Value!
    };

    public Patient? GetById(PersoonId id) {
        Patient? patient = null;

        foreach (Patient p in _patienten) {
            if (p.Id == id) {
                patient = p;
                break;
            }
        }
        return patient;
    }
    public Patient? GetByRrn(RijksRegisterNr rrn) {
        Patient? patient = null;

        foreach (Patient p in _patienten) {
            if (p.Rrn == rrn) {
                patient = p;
                break;
            }
        }
        return patient;
    }
    public IEnumerable<Patient> GetAll() {
        return _patienten;
    }
    public bool Insert(Patient patient) {
        if (patient is null) {
            throw new ArgumentNullException();
        }
        return _patienten.Add(patient);
    }
    public bool Update(Patient patient) {
        Patient? oldPatient = GetById(patient.Id);

        if (oldPatient is null) {
            return false;
        }

        Delete(oldPatient.Id);
        Insert(patient);
        return true;
    }
    public bool Delete(PersoonId id) {
        Patient? oldPatient = GetById(id);

        if (oldPatient is null) {
            return false;
        }

        return _patienten.Remove(oldPatient);
    }
}
