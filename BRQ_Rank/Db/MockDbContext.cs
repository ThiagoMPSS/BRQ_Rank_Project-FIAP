using BRQ_Rank.Models;

namespace BRQ_Rank.Db {
    public class MockDbContext {
        public MockDbContext() {
            _ = new PopularMockDbContext(this);
        }

        public List<Candidato> Candidato { get; set; } = new List<Candidato>();
        public List<Competencias> Competencias { get; set; } = new List<Competencias>();
        public List<Habilidade> Habilidade { get; set; } = new List<Habilidade>();
        public List<Idiomas> Idiomas { get; set; } = new List<Idiomas>();
        public List<Linguagem> Linguagem { get; set; } = new List<Linguagem>();
        public List<Skills> Skills { get; set; } = new List<Skills>();
        public List<Tecnologias> Tecnologias { get; set; } = new List<Tecnologias>();

    }

    class PopularMockDbContext {
        Random random = new Random();
        readonly MockDbContext db;

        public PopularMockDbContext(MockDbContext _mockDbContext) {
            db = _mockDbContext;
            PopularEntidades();
        }

        private void PopularEntidades() {
            for (int i = 0; i < 60; i++) {
                db.Competencias.Add(new Competencias($"Competencia {i}"));
            }
            for (int i = 0; i < 23; i++) {
                db.Idiomas.Add(new Idiomas($"Idioma {i}"));
            }
            for (int i = 0; i < 60; i++) {
                db.Tecnologias.Add(new Tecnologias($"Tecnologia {i}"));
            }

            for (int i = 0; i < 20; i++) {
                var day = random.Next(1, 31);
                var month = random.Next(1, 13);
                var year = random.Next(1930, 2005);
                var candidato = new Candidato($"Candidato {i}", i%2, new DateTime(), $"candidato{i}@teste.com", "", 
                                              new List<Habilidade>(), new List<Linguagem>(), new List<Skills>());
                for (int j = 0; j < 10; j++) {
                    candidato.Habilidades?.Add(new Habilidade(db.Competencias.OrderBy(x => random.Next()).First(), candidato, new DateTime()));
                }
                for (int j = 0; j < 10; j++) {
                    int nivel = new Random().Next(0,4);
                    candidato.Linguagens?.Add(new Linguagem(db.Idiomas.OrderBy(x => random.Next()).First(), candidato, nivel == 1 ? "Básico" : (nivel == 2 ? "Médio" : (nivel == 3 ? "Avançado" : "Nenhum"))));
                }
                for (int j = 0; j < 10; j++) {
                    candidato.Skills?.Add(new Skills(db.Tecnologias.OrderBy(x => random.Next()).First(), candidato, new DateTime()));
                }

                db.Candidato.Add(candidato);
            }
        }
    }
}