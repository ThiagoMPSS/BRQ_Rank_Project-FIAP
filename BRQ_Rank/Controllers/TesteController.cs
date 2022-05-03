using BRQ_Rank.Db;
using BRQ_Rank.Filtros;
using BRQ_Rank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BRQ_Rank.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase {
        readonly DatabaseContext db;

        public TesteController() {
            this.db = DatabaseContext.Instance;
        }

        [HttpGet]
        public IActionResult Gerar() {
            var ret = db.GetQuery(Nome:"Azola",/*Idioma: "Idioma4", Skill: "Tecnologia1", Competencia: "Competencia2",*/ Limite: 200);
            //Console.WriteLine(ret);

            return Ok(ret);

            //return Ok(db.Candidato.Where(e => e.Linguagens.Exists(e2 => e2.Tp_Nivel == "Básico" && e2.Idiomas.Tp_Idioma == "Idioma4") || e.Dt_Nasc.Year <= 1990).Take(10).ToArray());
        }

        [HttpGet, Route("AutoPopularDB")]
        public IActionResult AutoPopularDB() {
            try {
                new PopularDbContext((DatabaseContext)db);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex);
            }
        }
    }
}
