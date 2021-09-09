using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
         Task<Palestrante[]> GetAllPalestrantes(bool includeEvento = false);
         Task<Palestrante[]> GetAllPalestrantesByNome(string nome, bool includeEvento = false);
         Task<Palestrante> GetPalestranteById(int palestranteId, bool includeEvento = false);
    }
}