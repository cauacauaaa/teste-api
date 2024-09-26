namespace CidadeInteligente.Models
{
    public class ViolacaoModel
    {
        public int ViolacaoId { get; set; }
        public string? Tipo { get; set; }
        public string? Placa { get; set; }
        
        public DateTime Dia { get; set; }
        public string? Loc { get; set; }

    }
}