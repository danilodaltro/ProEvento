using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento(){
                EventoId = 1,
                Tema = ".NET 5 e Angular 11",
                Local = "Salvador",
                QtdPessoas = 300,
                Lote = "1",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy"),
                ImagemURL = "foto1.png"
            },
            new Evento(){
                EventoId = 2,
                Tema = "SQL Server",
                Local = "Feira de Santana",
                QtdPessoas = 500,
                Lote = "3",
                DataEvento = DateTime.Now.AddDays(5).ToString("dd/mm/yyyy"),
                ImagemURL = "foto3.png"

            }
        };

        public EventoController()
        {
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> Get(int id){
            return _evento.Where(x => x.EventoId.Equals(id));
        }

        [HttpPost]
        public string Post()
        {
            return "Retorno de POST";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Retorno de PUT com Id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Retorno de DELETE com Id = {id}";
        }
    }
}
