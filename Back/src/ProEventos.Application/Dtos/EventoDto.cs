using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        [Required( ErrorMessage = "O tema precisa ser informado."),
        StringLength(250, MinimumLength = 2, ErrorMessage = "O tema deve ter mais de dois caracteres.")]
        public string Tema { get; set; }
        public string Local { get; set; }
        public int QtdPessoas { get; set; }
        public string DataEvento { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<LoteDto> Lotes { get; set; }
        public IEnumerable<PalestranteDto> PalestrantesEventos { get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }
    }
}