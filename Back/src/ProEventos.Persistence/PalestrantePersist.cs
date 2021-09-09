using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext context;

        public PalestrantePersist(ProEventosContext context)
        {
            this.context = context;
            this.context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<Palestrante[]> GetAllPalestrantes(bool includeEvento = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                                    .Include(p => p.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNome(string nome, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                            .Include(p => p.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                        .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteById(int palestranteId, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = context.Palestrantes
                .Include(p => p.RedesSociais);

            if (includeEvento)
            {
                query = query.Include(p => p.PalestrantesEventos)
                            .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                        .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
    }
}