using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRQ_Rank.Models {
    [Table("T_Skills")]
    public class Skills {
        [Key, Column("Id_Skills")]
        public int Id { get; set; }
        [ForeignKey("Id_Tecnologias")]
        public Tecnologias? Tecnologias { get; set; }
        [ForeignKey("Id_Candidato")]
        public Candidato? Candidato { get; set; }
        [Required, Column("Dt_Certificado")]
        public DateTime Dt_Certificado { get; set; }

        public Skills() {

        }

        public Skills(Tecnologias? tecnologias, Candidato? candidato, DateTime dt_certificado) {
            Tecnologias = tecnologias;
            Candidato = candidato;
            Dt_Certificado = dt_certificado;
        }
    }
}
