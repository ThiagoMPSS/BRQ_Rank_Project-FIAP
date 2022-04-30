namespace BRQ_Rank.Models{
    public class Candidato
    {   
        public int Id { get;private set; }
        public string? Nm_Candidato { get; set; }
        public int Tp_Genero { get; set; }
        public DateTime Dt_Nasc { get; set; }
        public string? Email { get; set; }
        public string? Nm_Telefone { get; set; }

    }
}
