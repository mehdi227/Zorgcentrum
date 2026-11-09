using Microsoft.VisualBasic.FileIO;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded; 
public class OperatieRepository :IOperatieRepository {
    private HashSet<Operatie> _operaties = new() {
        Operatie.Create().Value!,
        Operatie.Create().Value!
    };

    public Operatie? GetById(AfspraakId id) {
        Operatie? operatie = null;

        foreach (Operatie o in _operaties) {
            if (o.AfspraakID == id) {
                operatie = o;
                break;
            }
        }
        return operatie;
    }

    public IEnumerable<Operatie> GetAll() {
        return _operaties;
    }

    public bool Insert(Operatie? operatie) {
        if (operatie is null) {
            throw new ArgumentNullException();
        }
        return _operaties.Add(operatie);
    }

    public bool Update(Operatie operatie) {
        Operatie? oldOperatie = GetById(operatie.AfspraakID);

        if (oldOperatie is null) {
            return false;
        }

        Delete(oldOperatie.AfspraakID);
        Insert(operatie);
        return true;
    }

    public bool Delete(AfspraakId id) {
        Operatie? oldOperatie = GetById(id);

        if (oldOperatie is null) {
            return false;
        }

        return _operaties.Remove(oldOperatie);
    }
}
