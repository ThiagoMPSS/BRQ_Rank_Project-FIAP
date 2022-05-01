using System.Collections.ObjectModel;

namespace BRQ_Rank.Models {
    public class Candidato {
        public int Id { get; set; }
        public string? Nm_Candidato { get; set; }
        public int Tp_Genero { get; set; }
        public DateTime Dt_Nasc { get; set; }
        public string? Email { get; set; }
        public string? Nm_Telefone { get; set; }
        public List<Habilidade>? Habilidades { get; set; }
        public List<Linguagem>? Linguagens { get; set; }
        public List<Skills>? Skills { get; set; }

        public Candidato() {

        }

        public Candidato(string? nm_Candidato, int tp_Genero, DateTime dt_Nasc, string? email, string? nm_Telefone) {
            Nm_Candidato = nm_Candidato;
            Tp_Genero = tp_Genero;
            Dt_Nasc = dt_Nasc;
            Email = email;
            Nm_Telefone = nm_Telefone;
        }

        public Candidato(string? nm_Candidato, int tp_Genero, DateTime dt_Nasc, string? email, string? nm_Telefone,
                         List<Habilidade> habilidades, List<Linguagem> linguagens, List<Skills> skills)
                         : this(nm_Candidato, tp_Genero, dt_Nasc, email, nm_Telefone) {
            Habilidades = habilidades;
            Linguagens = linguagens;
            Skills = skills;
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
                        $"<td>{Email}</td>" +
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

            return $"{Id}, {Nm_Candidato}, {Tp_Genero}, {Dt_Nasc}, {Email}, {Nm_Telefone}, {habs}, {lings}, {skills}\n";
        }
    }
} 
