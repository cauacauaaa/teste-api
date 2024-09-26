namespace CidadeInteligente.Models
{
    public class SemaforoModel
    {
        public int SemaforoId { get; set; }
        public string? Estado { get; set; }
        public int Duracao { get; set; }
        public string? Loc { get; set; }
    }
}