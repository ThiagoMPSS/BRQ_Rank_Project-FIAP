using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BRQ_Rank.Models{
    [Table ("T_Tecnologias")]
    public class Tecnologias{
        [Key, Column("Id_Tecnologias")]
        public int Id_Tecnologias { get; set; }
        [Required, Column("Tp_Tecnologias")]
        public string? Tp_Tecnologias { get; set; }

        public Tecnologias() {

        }

        public Tecnologias(string? tp_Tecnologias) {
            Tp_Tecnologias = tp_Tecnologias;
        }
    }
}
