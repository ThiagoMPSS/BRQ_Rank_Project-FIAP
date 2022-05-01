using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRQ_Rank.Models {
    [Table("T_Habilidade")]
    public class Habilidade {
        [ForeignKey ("Id_Competencias")]
        public Competencias? Competencias { get; set; }
        [ForeignKey("Id_Candidato")]
        public Candidato? Candidato { get; set; }
        [Required, Column("Dt_Certificacao")]
        public DateTime Dt_certificacao { get; set; }

        public Habilidade() {

        }

        public Habilidade(Competencias? competencias, Candidato? candidato, DateTime dt_certificacao) {
            Competencias = competencias;
            Candidato = candidato;
            Dt_certificacao = dt_certificacao;
        }
    }
}
