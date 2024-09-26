namespace CidadeInteligente.Models
{
    public class AcidenteModel
    {
        public int AcidenteId { get; set; }
        public string? Descricao { get; set; }
        public string? Severidade { get; set; }

        public DateTime Dia { get; set; }
        public string? Loc { get; set; }
    }
}