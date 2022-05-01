using System.Text.Json.Serialization;

namespace BRQ_Rank.Models {
    public class Idiomas {
        public int Id { get; set; }
        public string? Tp_Idioma { get; set; }
        public Linguagem Linguagem { get; set;}

        public Idiomas() {

        }

        public Idiomas(string? tp_Idioma) {
            Tp_Idioma = tp_Idioma;
        }
    }
}
