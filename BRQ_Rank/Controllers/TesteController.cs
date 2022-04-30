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
            return Ok(db.Candidato.Where(e => e.Linguagens.Exists(e2 => e2.Tp_Nivel == "Básico" && e2.Idiomas.Tp_Idioma == "Idioma4") || e.Dt_Nasc.Year <= 1990).Take(10).ToArray());
        }

    }
}
