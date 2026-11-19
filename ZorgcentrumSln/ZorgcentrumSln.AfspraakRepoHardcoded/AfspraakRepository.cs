using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded;

public class AfspraakRepository : IAfspraakRepository {

    private HashSet<Afspraak> _afspraken = new() {
        Consultatie.Create(
            AfspraakId.CreateUnique(),
            new DateTime(),
            30,
            AfdelingId.CreateUnique(),
            RijksRegisterNr.Create(),
            RizivNr.Create()
            ).Value!,
        Controle.Create(
            AfspraakId.CreateUnique(),
            new DateTime(2024, 7, 18, 14, 32, 45),
            10,
            AfdelingId.CreateUnique(),
            RijksRegisterNr.Create(),
            RizivNr.Create(),
            AfspraakId.CreateUnique()).Value!,
        Controle.Create(
            AfspraakId.CreateUnique(),
            new DateTime(2024, 8, 5, 9, 15, 30),
            15,
            AfdelingId.CreateUnique(),
            RijksRegisterNr.Create(),
            RizivNr.Create(),
            AfspraakId.CreateUnique()).Value!,
        Operatie.Create(
            AfspraakId.CreateUnique(),
            new DateTime (2019, 8, 5, 9, 15, 30),
            30,
            AfdelingId.CreateUnique(),
            RijksRegisterNr.Create(),
            RizivNr.Create(),
            "hart operatie"
            ).Value!
    };
    public Afspraak? GetById(AfspraakId id) {
        Afspraak? afspraak = null;

        foreach (Afspraak a in _afspraken) {
            if (a.AfspraakID == id) {
                afspraak = a;
                break;
            }
        }
        return afspraak;
    }
    public IEnumerable<Afspraak> GetAll() {
        return _afspraken;
    }
    public bool Insert(Afspraak afspraak) {
        if (afspraak is null) {
            throw new ArgumentNullException();
        }
        return _afspraken.Add(afspraak);
    }
    public bool Update(Afspraak afspraak) {
        Afspraak? oldAfspraak = GetById(afspraak.AfspraakID);

        if (oldAfspraak is null) {
            return false;
        }

        Delete(oldAfspraak.AfspraakID);
        Insert(afspraak);
        return true;
    }
    public bool Delete(AfspraakId id) {
        Afspraak? oldAfspraak = GetById(id);

        if (oldAfspraak is null) {
            return false;
        }

        return _afspraken.Remove(oldAfspraak);
    }
}
