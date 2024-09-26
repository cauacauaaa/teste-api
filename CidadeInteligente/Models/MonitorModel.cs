namespace CidadeInteligente.Models
{
    public class MonitorModel
    {
        public int MonitorId;
        public DateTime Dia { get; set; }
        public string? Loc { get; set; }
        public int ContVeic { get; set; }
        public double VelMedia { get; set; }



    }
}