using BRQ_Rank.Db;
using BRQ_Rank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRQ_Rank.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase {
        readonly MockDbContext db;
        public TesteController(MockDbContext _mockDbContext) {
            this.db = _mockDbContext;
        }

        string ToHtml(Candidato[] candidatos) {
            var html = "<style>table, th, td {border: 1px solid;}</style>" +
                "<table style='white-space: nowrap;'>" +
                $"<tr>" +
                    $"<th>Id</th>" +
                    $"<th>Nm_Candidato</th>" +
                    $"<th>Tp_Genero</th>" +
                    $"<th>Dt_Nasc</th>" +
                    $"<th>Email</th>" +
                    $"<th>Nm_Telefone</th>" +
                    $"<th>habs</th>" +
                    $"<th>lings</th>" +
                    $"<th>skills</th>" +
                $"</tr>";
            foreach (var c in candidatos) {
                html += c.ToHtml();
            }
            html += "</table>";
            return html;
        }

        string ToCsv(Candidato[] candidatos) {
            var csv = "Id, Nm_Candidato, Tp_Genero, Dt_Nasc, Email, Nm_Telefone, habs, lings, skills\n";
            foreach (var c in candidatos) {
                csv += c.ToCsv();
            }
            return csv;
        }

        [HttpGet]
        public IActionResult Gerar() {
            var QueryByLevelIdioma = (from c in db.Candidato
                                      join l in db.Linguagem on c.Id equals l.Candidato.Id
                                      join i in db.Idiomas on l.Idiomas.Id equals i.Id
                                      orderby (l.Tp_Nivel == "Avançado" && i.Tp_Idioma == "Idioma4" ? 0 : (l.Tp_Nivel == "Médio" && i.Tp_Idioma == "Idioma4" ? 1 : l.Tp_Nivel == "Básico" && i.Tp_Idioma == "Idioma4" ? 2 : 3))
                                      select c).DistinctBy(c => c.Id).Take(50);

            return Ok(QueryByLevelIdioma);

            //return Ok(db.Candidato.Where(e => e.Linguagens.Exists(e2 => e2.Tp_Nivel == "Básico" && e2.Idiomas.Tp_Idioma == "Idioma4") || e.Dt_Nasc.Year <= 1990).Take(10).ToArray());
        }

    }
}
