using Microsoft.VisualBasic.FileIO;
using ZorgcentrumSln.BL.Afspraken;
using ZorgcentrumSln.BL.Interfaces;
using ZorgcentrumSln.Buildingblocks.ValueObjects;

namespace ZorgcentrumSln.Infrastructuur.PersistentieHardcoded {
    public class ConsultatieRepository : IConsultatieRepository {
        private HashSet<Consultatie> _afspraken = new() {
            Consultatie.Create(
                AfspraakId.CreateUnique(),
                new DateTime(),
                30,
                AfdelingId.CreateUnique(),
                PersoonId.CreateUnique(),
                PersoonId.CreateUnique()
                ).Value!
        };
        public Consultatie? GetById(AfspraakId id) {
            Consultatie? consultatie = null;

            foreach (Consultatie c in _afspraken) {
                if (c.AfspraakID == id) {
                    consultatie = c;
                    break;
                }
            }
            return consultatie;
        }
        public IEnumerable<Consultatie> GetAll() {
            return _afspraken;
        }
        public bool Insert(Consultatie consultatie) {
            if (consultatie == null) {
                throw new ArgumentNullException();
            }
            return _afspraken.Add(consultatie);
        }
        public bool Update(Consultatie consultatie) {
            Consultatie? oldConsultatie = GetById(consultatie.AfspraakID);

            if (oldConsultatie is null) {
                return false;
            }

            Delete(consultatie.AfspraakID);
            Insert(consultatie);
            return true;
        }
        public bool Delete(AfspraakId id) {
            Consultatie? oldConsultatie = GetById(id);

            if (oldConsultatie is null) {
                return false;
            }

            return _afspraken.Remove(oldConsultatie);
        }
    }
}
