using System;
using System.Threading.Tasks;
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        private readonly IEventoPersist eventoPersist;
        private readonly IMapper mapper;
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist, IMapper mapper)
        {
            this.geralPersist = geralPersist;
            this.eventoPersist = eventoPersist;
            this.mapper = mapper;
        }

        public async Task<EventoDto> AddEvento(EventoDto model)
        {
            try
            {
                var evento = mapper.Map<Evento>(model);
                geralPersist.Add<Evento>(evento);
                if (await geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> UpdateEvento(int eventoId, EventoDto model)
        {
            try
            {
                var evento = await eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;

                model.Id = evento.Id;
                mapper.Map(model,evento);

                geralPersist.Update<Evento>(evento);

                if (await geralPersist.SaveChangesAsync())
                {
                    var eventoRetorno = await eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return mapper.Map<EventoDto>(eventoRetorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                Evento evento = await eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("O evento a ser deletado não foi encontrado.");

                geralPersist.Delete<Evento>(evento);
                return await geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrante = false)
        {
            try
            {
                var eventos = await eventoPersist.GetAllEventosAsync(includePalestrante);
                if (eventos == null) return null;

                var resultado = mapper.Map<EventoDto[]>(eventos);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrante = false)
        {
            try
            {
                var eventos = await eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrante);
                if (eventos == null) return null;

                var resultado = mapper.Map<EventoDto[]>(eventos);

                return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrante = false)
        {
            try
            {
                var evento = await eventoPersist.GetEventoByIdAsync(eventoId, includePalestrante);
                if (evento == null) return null;

                var resultado = mapper.Map<EventoDto>(evento);

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}