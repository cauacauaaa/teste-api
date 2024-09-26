using CidadeInteligente.Models;

namespace CidadeInteligente.ViewModel
{
    public class ViolacaoViewModel
    {
        public int ViolacaoId { get; set; }
        public string? Tipo { get; set; }
        public string? Placa { get; set; }
        public DateTime Dia { get; set; }
    }
}
