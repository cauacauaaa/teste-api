using CidadeInteligente.Models;

namespace CidadeInteligente.ViewModel
{
    public class AcidenteViewModel
    {
        public int AcidenteId { get; set; }
        public string? Descricao { get; set; }
        public string? Severidade { get; set; }
        public DateTime Dia { get; set; }
    }
}
