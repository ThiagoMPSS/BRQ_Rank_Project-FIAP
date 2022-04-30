namespace BRQ_Rank.Models {
    public class Skills {
        public Tecnologias? Tecnologias { get; set; }
        public Candidato? Candidato;
        public DateTime Dt_certificado { get; set; }

        public Skills() {

        }

        public Skills(Tecnologias? tecnologias, Candidato? candidato, DateTime dt_certificado) {
            Tecnologias = tecnologias;
            Candidato = candidato;
            Dt_certificado = dt_certificado;
        }
    }
}
