namespace BRQ_Rank.Models {
    public class Idiomas {
        public int Id { get; private set; }
        public string? Tp_Idioma { get; private set; }

        public Idiomas() {

        }

        public Idiomas(string? tp_Idioma) {
            Tp_Idioma = tp_Idioma;
        }
    }
}
