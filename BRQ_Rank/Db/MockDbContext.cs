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

    class PopularDbContext {
        Random random = new Random();
        readonly DatabaseContext db;

        public PopularDbContext(DatabaseContext db) {
            this.db = db;
            PopularEntidades();
        }

        private void PopularEntidades() {
            Console.WriteLine("Populando Competencias...");
            for (int i = 0; i < 60; i++) {
                db.Competencias.Add(new Competencias($"Competencia{i}"));
            }
            Console.WriteLine("Populando Idiomas...");
            for (int i = 0; i < 23; i++) {
                db.Idiomas.Add(new Idiomas($"Idioma{i}"));
            }
            Console.WriteLine("Populando Tecnologias...");
            for (int i = 0; i < 60; i++) {
                db.Tecnologias.Add(new Tecnologias($"Tecnologia{i}"));
            }
            db.SaveChanges();

            var comps = db.Competencias.ToList();
            var idiomas = db.Idiomas.ToList();
            var tecnologias = db.Tecnologias.ToList();

            Console.WriteLine("Populando Candidatos...");
            for (int i = 0; i < 100; i++) {
                var day = random.Next(1, 29);
                var month = random.Next(1, 13);
                var year = random.Next(1930, 2005);
                var habs = new List<Habilidade>();
                var lings = new List<Linguagem>();
                var skills = new List<Skills>();
                var candidato = new Candidato($"Candidato {i}", i % 2, new DateTime(year, month, day), $"candidato{i}@teste.com", "" + random.Next(111111111, 999999999));

                for (int j = 0; j < random.Next(11); j++) {
                    int rn = random.Next(comps.Count());
                    var h = new Habilidade(comps[rn], candidato, new DateTime());
                    if (habs.Exists(habilidade => habilidade.Competencias.Id == h.Competencias.Id))
                        continue;

                    habs.Add(h);
                }
                for (int j = 0; j < random.Next(11); j++) {
                    int rn = random.Next(idiomas.Count());
                    int nivel = new Random().Next(0, 4);
                    if (nivel == 0)
                        continue;
                    var l = new Linguagem(idiomas[rn], candidato, nivel == 1 ? LinguagemNivel.Basico : (nivel == 2 ? LinguagemNivel.Medio : (nivel == 3 ? LinguagemNivel.Avancado : LinguagemNivel.Nenhum)));
                    if (lings.Exists(lingua => lingua.Idiomas.Id_idioma == l.Idiomas.Id_idioma))
                        continue;

                    lings.Add(l);
                }
                for (int j = 0; j < random.Next(11); j++) {
                    int rn = random.Next(tecnologias.Count());
                    var t = new Skills(tecnologias[rn], candidato, new DateTime());
                    if (skills.Exists(skill => skill.Tecnologias.Id_Tecnologias == t.Tecnologias.Id_Tecnologias))
                        continue;

                    skills.Add(t);
                }

                candidato.Habilidades = habs;
                candidato.Skills = skills;
                candidato.Linguagens = lings;
                db.Candidato.Add(candidato);
            }
            Console.WriteLine("População Concluida.");
            db.SaveChanges();
            Console.WriteLine("População Salva.");
        }
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
                db.Idiomas.Add(new Idiomas($"Idioma{i}") { Id_idioma = i});
            }
            for (int i = 0; i < 60; i++) {
                db.Tecnologias.Add(new Tecnologias($"Tecnologia{i}") { Id_Tecnologias = i});
            }

            for (int i = 0; i < 80000; i++) {
                var day = random.Next(1, 29);
                var month = random.Next(1, 13);
                var year = random.Next(1930, 2005);
                var candidato = new Candidato($"Candidato {i}", i%2, new DateTime(year, month, day), $"candidato{i}@teste.com", "", 
                                              new List<Habilidade>(), new List<Linguagem>(), new List<Skills>()) { Id = i};

                for (int j = 0; j < random.Next(11); j++) {
                    var h = new Habilidade(db.Competencias.OrderBy(x => random.Next()).First(), candidato, new DateTime());
                    if (candidato.Habilidades.Exists(habilidade => habilidade.Competencias.Id == h.Competencias.Id))
                        continue;
                    db.Habilidade.Add(h);

                    candidato.Habilidades?.Add(h);
                }
                for (int j = 0; j < random.Next(11); j++) {
                    int nivel = new Random().Next(0, 4);
                    if (nivel == 0)
                        continue;
                    var l = new Linguagem(db.Idiomas.OrderBy(x => random.Next()).First(), candidato, nivel == 1 ? LinguagemNivel.Basico : (nivel == 2 ? LinguagemNivel.Medio : (nivel == 3 ? LinguagemNivel.Avancado : LinguagemNivel.Nenhum)));
                    if (candidato.Linguagens.Exists(lingua => lingua.Idiomas.Id_idioma == l.Idiomas.Id_idioma))
                        continue;
                    db.Linguagem.Add(l);

                    candidato.Linguagens?.Add(l);
                }
                for (int j = 0; j < random.Next(11); j++) {
                    var t = new Skills(db.Tecnologias.OrderBy(x => random.Next()).First(), candidato, new DateTime());
                    if (candidato.Skills.Exists(skills => skills.Tecnologias.Id_Tecnologias == t.Tecnologias.Id_Tecnologias))
                        continue;
                    db.Skills.Add(t);

                    candidato.Skills?.Add(t);
                }

                db.Candidato.Add(candidato);
            }
        }
    }
}