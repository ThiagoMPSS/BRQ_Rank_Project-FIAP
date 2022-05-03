using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BRQ_Rank.Models {
    [Table("T_Idiomas")]
    public class Idiomas {
        [Key, Column("id_Idioma")]
        public int Id_idioma { get; set; }
        [Required, Column("Tp_Idioma")]
        public string? Tp_Idioma { get; set; }

        public Idiomas() {

        }

        public Idiomas(string? tp_Idioma) {
            Tp_Idioma = tp_Idioma;
        }
    }
}
