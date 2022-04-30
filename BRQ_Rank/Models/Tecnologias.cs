namespace BRQ_Rank.Models{
    public class Tecnologias{
        public int Id { get; private set; }
        public string? Tp_Tecnologias { get; private set; }

        public Tecnologias() {

        }

        public Tecnologias(string? tp_Tecnologias) {
            Tp_Tecnologias = tp_Tecnologias;
        }
    }
}
