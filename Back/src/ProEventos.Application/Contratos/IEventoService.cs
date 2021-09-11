using System.Threading.Tasks;
using ProEventos.Application.Dtos;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<EventoDto> AddEvento(EventoDto eventoDto);
        Task<EventoDto> UpdateEvento(int eventoId, EventoDto eventoDto);
        Task<bool> DeleteEvento(int eventoId);
        Task<EventoDto[]> GetAllEventosAsync(bool includePalestrante = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false);
        Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrante = false);
    }
}