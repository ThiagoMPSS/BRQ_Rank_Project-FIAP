using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRQ_Rank.Models {
    [Table("T_Linguagem")]
    public class Linguagem{
        [ForeignKey("Id_Idiomas")]
        public Idiomas? Idiomas { get; set; }
        [ForeignKey("Id_Candidato")]
        public Candidato? Candidato { get; set; }
        [Required, Column("Tp_Nivel")]
        public LinguagemNivel Tp_Nivel { get; set; }

        public Linguagem() {

        }

        public Linguagem(Idiomas? idiomas, Candidato? candidato, LinguagemNivel tp_Nivel) {
            Idiomas = idiomas;
            Candidato = candidato;
            Tp_Nivel = tp_Nivel;
        }
    }
}
