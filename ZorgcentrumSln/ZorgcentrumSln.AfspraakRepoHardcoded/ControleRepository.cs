using System.Xml.Linq;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded; 
public class ControleRepository: IControleRepository {
    private HashSet<Controle> _controles = new() {
        Controle.Create().Value!,
        Controle.Create().Value!
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
