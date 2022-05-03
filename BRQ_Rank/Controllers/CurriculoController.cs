using BRQ_Rank.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BRQ_Rank.Models;
using Microsoft.EntityFrameworkCore;
using BRQ_Rank.Filtros;

namespace BRQ_Rank.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculoController : ControllerBase {
        readonly DatabaseContext db;

        public CurriculoController() {
            this.db = DatabaseContext.Instance;
        }

        #region Candidato
        [HttpGet, Route("GetCandidato")]
        public IActionResult GetCandidato(int Id) {
            try {
                db.ChangeTracker.Clear();
                var candidato = db.Candidato.Include(c => c.Habilidades).Include(c => c.Linguagens).Include(c => c.Skills).Where(c => c.Id == Id);
                return Ok(candidato);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpGet, Route("BuscarCandidato")]
        public IActionResult BuscarCandidato(string? Idioma = "", string? Skill = "", string? Competencia = "",
                                             bool SomenteSkill = false, bool SomenteCompetencia = false, bool SomenteIdioma = false,
                                             string? Nome = "", string? Email = "", string? Telefone = "",
                                             int Limite = 10) {
            try {
                db.ChangeTracker.Clear();
                var ret = db.GetQuery(Idioma, Skill, Competencia, SomenteSkill, SomenteCompetencia, SomenteIdioma, Nome, Email, Telefone, Limite);
                return Ok(ret);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddCandidato")]
        public IActionResult AddCandidato(Candidato candidato) {
            try {
                db.ChangeTracker.Clear();
                db.Candidato.Add(candidato);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarCandidato")]
        public IActionResult AlterarCandidato(Candidato candidato) {
            try {
                db.ChangeTracker.Clear();
                db.Candidato.Update(candidato);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarCandidato")]
        public IActionResult DeletarCandidato(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Candidato.Remove(db.Candidato.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion

        #region Habilidade
        [HttpGet, Route("GetHabilidade")]
        public IActionResult GetHabilidade(int Id) {
            try {
                db.ChangeTracker.Clear();
                return Ok(db.Habilidade.Include(h => h.Candidato).Include(h => h.Competencias).Where(h => h.Id == Id));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddHabilidade")]
        public IActionResult AddHabilidade(Habilidade Habilidade) {
            try {
                db.ChangeTracker.Clear();
                db.Habilidade.Add(Habilidade);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarHabilidade")]
        public IActionResult AlterarHabilidade(Habilidade Habilidade) {
            try {
                db.ChangeTracker.Clear();
                db.Habilidade.Update(Habilidade);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarHabilidade")]
        public IActionResult DeletarHabilidade(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Habilidade.Remove(db.Habilidade.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion

        #region Competencias
        [HttpGet, Route("GetCompetencias")]
        public IActionResult GetCompetencias(int Id) {
            try {
                db.ChangeTracker.Clear();
                return Ok(db.Competencias.Find(Id));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddCompetencias")]
        public IActionResult AddCompetencias(Competencias Competencias) {
            try {
                db.ChangeTracker.Clear();
                db.Competencias.Add(Competencias);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarCompetencias")]
        public IActionResult AlterarCompetencias(Competencias Competencias) {
            try {
                db.ChangeTracker.Clear();
                db.Competencias.Update(Competencias);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarCompetencias")]
        public IActionResult DeletarCompetencias(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Competencias.Remove(db.Competencias.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion

        #region Linguagem
        [HttpGet, Route("GetLinguagem")]
        public IActionResult GetLinguagem(int Id) {
            try {
                db.ChangeTracker.Clear();
                return Ok(db.Linguagem.Include(l => l.Candidato).Include(l => l.Idiomas).Where(l => l.Id == Id));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddLinguagem")]
        public IActionResult AddLinguagem(Linguagem Linguagem) {
            try {
                db.ChangeTracker.Clear();
                db.Linguagem.Add(Linguagem);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarLinguagem")]
        public IActionResult AlterarLinguagem(Linguagem Linguagem) {
            try {
                db.ChangeTracker.Clear();
                db.Linguagem.Update(Linguagem);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarLinguagem")]
        public IActionResult DeletarLinguagem(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Linguagem.Remove(db.Linguagem.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion

        #region Idiomas
        [HttpGet, Route("GetIdiomas")]
        public IActionResult GetIdiomas(int Id) {
            try {
                db.ChangeTracker.Clear();
                return Ok(db.Idiomas.Find(Id));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddIdiomas")]
        public IActionResult AddIdiomas(Idiomas Idiomas) {
            try {
                db.ChangeTracker.Clear();
                db.Idiomas.Add(Idiomas);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarIdiomas")]
        public IActionResult AlterarIdiomas(Idiomas Idiomas) {
            try {
                db.ChangeTracker.Clear();
                db.Idiomas.Update(Idiomas);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarIdiomas")]
        public IActionResult DeletarIdiomas(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Idiomas.Remove(db.Idiomas.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion

        #region Skills
        [HttpGet, Route("GetSkills")]
        public IActionResult GetSkills(int Id) {
            try {
                db.ChangeTracker.Clear();
                return Ok(db.Skills.Include(s => s.Tecnologias).Include(s => s.Candidato).Where(s => s.Id == Id));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddSkills")]
        public IActionResult AddSkills(Skills Skills) {
            try {
                db.ChangeTracker.Clear();
                db.Skills.Add(Skills);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarSkills")]
        public IActionResult AlterarSkills(Skills Skills) {
            try {
                db.ChangeTracker.Clear();
                db.Skills.Update(Skills);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarSkills")]
        public IActionResult DeletarSkills(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Skills.Remove(db.Skills.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion

        #region Tecnologias
        [HttpGet, Route("GetTecnologias")]
        public IActionResult GetTecnologias(int Id) {
            try {
                db.ChangeTracker.Clear();
                return Ok(db.Tecnologias.Find(Id));
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPost, Route("AddTecnologias")]
        public IActionResult AddTecnologias(Tecnologias Tecnologias) {
            try {
                db.ChangeTracker.Clear();
                db.Tecnologias.Add(Tecnologias);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpPut, Route("AlterarTecnologias")]
        public IActionResult AlterarTecnologias(Tecnologias Tecnologias) {
            try {
                db.ChangeTracker.Clear();
                db.Tecnologias.Update(Tecnologias);
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }

        [HttpDelete, Route("DeletarTecnologias")]
        public IActionResult DeletarTecnologias(int Id) {
            try {
                db.ChangeTracker.Clear();
                db.Tecnologias.Remove(db.Tecnologias.Find(Id));
                db.SaveChanges();

                return Ok();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return BadRequest(ex);
            }
        }
        #endregion


    }
}