using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded;

public class ControleRepository : IControleRepository {
    private HashSet<Controle> _controles = new() {
        Controle.Create(AfspraakId.CreateUnique(),
            new DateTime(2024, 7, 18, 14, 32, 45),
            10,
            AfdelingId.CreateUnique(),
            PersoonId.CreateUnique(),
            PersoonId.CreateUnique(),
            AfspraakId.CreateUnique()).Value!,
        Controle.Create(AfspraakId.CreateUnique(),
            new DateTime(2024, 8, 5, 9, 15, 30),
            15,
            AfdelingId.CreateUnique(),
            PersoonId.CreateUnique(),
            PersoonId.CreateUnique(),
            AfspraakId.CreateUnique()).Value!,
        Controle.Create(AfspraakId.CreateUnique(),
            new DateTime(2024, 9, 12, 11, 45, 0),
            20,
            AfdelingId.CreateUnique(),
            PersoonId.CreateUnique(),
            PersoonId.CreateUnique(),
            AfspraakId.CreateUnique()).Value!
    };

    public Controle? GetById(AfspraakId id) {
        Controle? controle = null;

        foreach (Controle c in _controles) {
            if (c.AfspraakID == id) {
                controle = c;
                break;
            }
        }
        return controle;
    }

    public IEnumerable<Controle> GetAll() {
        return _controles;
    }

    public bool Insert(Controle? controle) {
        if (controle is null) {
            throw new ArgumentNullException();
        }
        return _controles.Add(controle);
    }

    public bool Update(Controle controle) {
        Controle? oldControle = GetById(controle.AfspraakID);

        if (oldControle is null) {
            return false;
        }

        Delete(oldControle.AfspraakID);
        Insert(controle);
        return true;
    }

    public bool Delete(AfspraakId id) {
        Controle? oldControle = GetById(id);

        if (oldControle is null) {
            return false;
        }

        return _controles.Remove(oldControle);
    }
}
