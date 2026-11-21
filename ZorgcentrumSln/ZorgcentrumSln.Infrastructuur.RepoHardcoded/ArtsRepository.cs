using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.BL.Personen;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded; 
public class ArtsRepository : IArtsRepository {
    private HashSet<Arts> _artsen = new() {
        Arts.Create(PersoonId.CreateUnique(),
            RijksRegisterNr.Create("85073012345").Value!,
            "naam1",
            "voornaam1",
            new DateOnly(2003,01,31),
            "specialisatie1",
            RizivNr.Create("10001234567").Value!
            ).Value!
    };

    public Arts? GetById(PersoonId id) {
        Arts? arts = null;

        foreach (Arts a in _artsen) {
            if (a.Id == id) {
                arts = a;
                break;
            }
        }
        return arts;
    }
    public Arts? GetByRrn(RijksRegisterNr rrn) {
        Arts? arts = null;

        foreach (Arts p in _artsen) {
            if (p.Rrn == rrn) {
                arts = p;
                break;
            }
        }
        return arts;
    }
    public IEnumerable<Arts> GetAll() {
        return _artsen;
    }
    public bool Insert(Arts arts) {
        if (arts is null) {
            throw new ArgumentNullException();
        }
        return _artsen.Add(arts);
    }
    public bool Update(Arts arts) {
        Arts? oldArts = GetById(arts.Id);

        if (oldArts is null) {
            return false;
        }

        Delete(oldArts.Id);
        Insert(arts);
        return true;
    }
    public bool Delete(PersoonId id) {
        Arts? oldArts = GetById(id);

        if (oldArts is null) {
            return false;
        }

        return _artsen.Remove(oldArts);
    }
}
