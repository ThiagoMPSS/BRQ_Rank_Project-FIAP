namespace BRQ_Rank.Models{
    public class Tecnologias{
        public int Id { get; set; }
        public string? Tp_Tecnologias { get; set; }

        public Skills Skills  { get; set; }

        public Tecnologias() {

        }

        public Tecnologias(string? tp_Tecnologias) {
            Tp_Tecnologias = tp_Tecnologias;
        }
    }
}
