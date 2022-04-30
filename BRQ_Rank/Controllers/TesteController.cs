using BRQ_Rank.Db;
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

        [HttpGet]
        public IActionResult Gerar() {

            return Ok(db.Candidato);
        }

    }
}
