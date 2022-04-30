namespace BRQ_Rank.Models {
    public class Skill {
        public Tecnologias? Tecnologias;
        public Candidato? Candidato;
        public DateTime Dt_certificado { get; set; }

        public Skill() {

        }

        public Skill(Tecnologias? tecnologias, Candidato? candidato, DateTime dt_certificado) {
            Tecnologias = tecnologias;
            Candidato = candidato;
            Dt_certificado = dt_certificado;
        }
    }
}
