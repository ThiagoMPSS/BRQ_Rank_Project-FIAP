using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRQ_Rank.Models {
    [Table("T_Competencias")]
    public class Competencias {
        [Key, Column("Id_Competencia")]
        public int Id { get; set; }
        [Required, Column("Tp_Competencia")]
        public string? Tp_Competencia { get; set; }

        public Competencias() {

        }

        public Competencias(string? tp_Competencia) {
            Tp_Competencia = tp_Competencia;
        }
    }
}
