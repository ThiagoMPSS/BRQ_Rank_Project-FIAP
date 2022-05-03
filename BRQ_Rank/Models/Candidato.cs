using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BRQ_Rank.Models {
    [Table("T_Candidato")]
    public class Candidato {
        [Key, Column("Id_Candidato")]
        public int Id { get; set; }
        [Required, Column("Nm_Candidato")]
        public string? Nm_Candidato { get; set; }
        [Required, Column("Tp_Genero")]
        public int Tp_Genero { get; set; }
        [Required, Column("Dt_Nasc")]
        public DateTime Dt_Nasc { get; set; }
        [Required, Column("Nm_Email")]
        public string? Nm_Email { get; set; }
        [Required, Column("Nm_Telefone")]
        public string? Nm_Telefone { get; set; }
        [NotMapped, JsonIgnore]
        private List<Habilidade>? _Habilidade;
        [NotMapped, JsonIgnore]
        public List<Habilidade>? Habilidades {
            get {
                return _Habilidade;
            } set {
                value = value.Select(h => { h.Candidato = this; return h; }).ToList();
                _Habilidade = value;
            }
        }
        [NotMapped, JsonIgnore]
        private List<Linguagem>? _Linguagens;
        [NotMapped, JsonIgnore]
        public List<Linguagem>? Linguagens { 
            get {
                return _Linguagens;
            } set {
                value = value.Select(v => { v.Candidato = this; return v; }).ToList();
                _Linguagens = value;
            }
        }
        [NotMapped, JsonIgnore]
        private List<Skills>? _Skills;
        [NotMapped, JsonIgnore]
        public List<Skills>? Skills {
            get {
                return _Skills;
            } set {
                value = value.Select(s => { s.Candidato = this; return s; }).ToList();
                _Skills = value;
            }
        }

        public Candidato() {

        }

        public Candidato(string? nm_Candidato, int tp_Genero, DateTime dt_Nasc, string? email, string? nm_Telefone) {
            Nm_Candidato = nm_Candidato;
            Tp_Genero = tp_Genero;
            Dt_Nasc = dt_Nasc;
            Nm_Email = email;
            Nm_Telefone = nm_Telefone;
        }

        public Candidato(string? nm_Candidato, int tp_Genero, DateTime dt_Nasc, string? email, string? nm_Telefone,
                         List<Habilidade> habilidades, List<Linguagem> linguagens, List<Skills> skills)
                         : this(nm_Candidato, tp_Genero, dt_Nasc, email, nm_Telefone) {
            Habilidades = habilidades;
            Linguagens = linguagens;
            Skills = skills;

            habilidades.Select(h => h.Candidato = this);
            linguagens.Select(l => l.Candidato = this);
            skills.Select(s => s.Candidato = this);
        }

        string Map<T>(T[] objs, Func<T, string> func) {
            string ret = "";
            foreach (var obj in objs) {
                ret += func(obj);
            }
            return ret;
        }

        public string ToHtml() {
            var habs = Map(Habilidades.ToArray(), h => h.Competencias.Tp_Competencia + ", ");
            var lings = Map(Linguagens.ToArray(), l => l.Idiomas.Tp_Idioma + ", ");
            var skills = Map(Skills.ToArray(), s => s.Tecnologias.Tp_Tecnologias + ", ");

            return $"<tr>" +
                        $"<td>{Id}</td>" +
                        $"<td>{Nm_Candidato}</td>" +
                        $"<td>{Tp_Genero}</td>" +
                        $"<td>{Dt_Nasc}</td>" +
                        $"<td>{Nm_Email}</td>" +
                        $"<td>{Nm_Telefone}</td>" +
                        $"<td>{habs}</td>" +
                        $"<td>{lings}</td>" +
                        $"<td>{skills}</td>" +
                    $"</tr>";
        }

        public string ToCsv() {
            var habs = Map(Habilidades.ToArray(), h => h.Competencias.Tp_Competencia + "; ");
            var lings = Map(Linguagens.ToArray(), l => l.Idiomas.Tp_Idioma + " = " + l.Tp_Nivel + "; ");
            var skills = Map(Skills.ToArray(), s => s.Tecnologias.Tp_Tecnologias + "; ");

            return $"{Id}, {Nm_Candidato}, {Tp_Genero}, {Dt_Nasc}, {Nm_Email}, {Nm_Telefone}, {habs}, {lings}, {skills}\n";
        }
    }
}
