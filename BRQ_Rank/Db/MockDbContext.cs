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
                db.Competencias.Add(new Competencias($"Competencia{i}") { Id = i});
            }
            for (int i = 0; i < 23; i++) {
                db.Idiomas.Add(new Idiomas($"Idioma{i}") { Id = i});
            }
            for (int i = 0; i < 60; i++) {
                db.Tecnologias.Add(new Tecnologias($"Tecnologia{i}") { Id = i});
            }

            for (int i = 0; i < 200; i++) {
                var day = random.Next(1, 29);
                var month = random.Next(1, 13);
                var year = random.Next(1930, 2005);
                var candidato = new Candidato($"Candidato {i}", i%2, new DateTime(year, month, day), $"candidato{i}@teste.com", "", 
                                              new List<Habilidade>(), new List<Linguagem>(), new List<Skills>()) { Id = i};

                for (int j = 0; j < random.Next(11); j++) {
                    var h = db.Competencias.OrderBy(x => random.Next()).First();
                    if (candidato.Habilidades.Exists(habilidade => habilidade.Competencias.Id == h.Id))
                        continue;

                    candidato.Habilidades?.Add(new Habilidade(h, candidato, new DateTime()));
                }
                for (int j = 0; j < random.Next(11); j++) {
                    int nivel = new Random().Next(0,4);
                    var l = db.Idiomas.OrderBy(x => random.Next()).First();
                    if (candidato.Linguagens.Exists(lingua => lingua.Idiomas.Id == l.Id))
                        continue;

                    candidato.Linguagens?.Add(new Linguagem(l, candidato, nivel == 1 ? "Básico" : (nivel == 2 ? "Médio" : (nivel == 3 ? "Avançado" : "Nenhum"))));
                }
                for (int j = 0; j < random.Next(11); j++) {
                    var t = db.Tecnologias.OrderBy(x => random.Next()).First();
                    if (candidato.Skills.Exists(skills => skills.Tecnologias.Id == t.Id))
                        continue;

                    candidato.Skills?.Add(new Skills(t, candidato, new DateTime()));
                }

                db.Candidato.Add(candidato);
            }
        }
    }
}