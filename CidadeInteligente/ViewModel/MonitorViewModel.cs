using CidadeInteligente.Models;

namespace CidadeInteligente.ViewModel
{
    public class MonitorViewModel
    {
        public int MonitorId { get; set; }
        public DateTime Dia { get; set; }
        public string? Loc { get; set; }
        public int ContVeic { get; set; }
        public double VelMedia { get; set; }
    }
}
