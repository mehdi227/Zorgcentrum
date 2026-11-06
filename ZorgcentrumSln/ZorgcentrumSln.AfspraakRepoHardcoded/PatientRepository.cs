using System.Net.Http.Headers;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded; 
public class PatientRepository : IPatientRepository{
    private HashSet<Patient> _patienten = new() {
        Patient.Create().Value!,
        Patient.Create().Value!,
        Patient.Create().Value!,
        Patient.Create().Value!,
        Patient.Create().Value!,
        Patient.Create().Value!,
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

        Delete(patient.Id);
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
