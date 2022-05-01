using BRQ_Rank.Db;

namespace BRQ_Rank.Filtros {
    public static class AlgoritmoBusca {
        public static object GetQuery(this MockDbContext db, string? Idioma = "", string? Skill = "", string? Competencia = null,
                                             bool SomenteSkill = false, bool SomenteCompetencia = false, bool SomenteIdioma = false,
                                             string? Nome = "", string? CPF = "", string? Email = "", string? Telefone = "",
                                             bool? LinguagemNivelDesc = null, int Limite = 0) {
            var query = from c in db.Candidato
                        join l in db.Linguagem on c.Id equals l.Candidato.Id
                        join i in db.Idiomas on l.Idiomas.Id equals i.Id
                        join s in db.Skills on c.Id equals s.Candidato.Id
                        join t in db.Tecnologias on s.Tecnologias.Id equals t.Id
                        join h in db.Habilidade on c.Id equals h.Candidato.Id
                        join cp in db.Competencias on h.Competencias.Id equals cp.Id
                        select new {
                            c.Id,
                            c.Nm_Candidato,
                            c.Nm_Telefone,
                            c.Email,
                            l.Tp_Nivel,
                            i.Tp_Idioma,
                            s.Dt_certificado,
                            t.Tp_Tecnologias,
                            h.Dt_certificacao,
                            cp.Tp_Competencia,
                            Skills = c.Skills.Select(s => new { s.Tecnologias.Tp_Tecnologias, s.Dt_certificado }),
                            Habilidades = c.Habilidades.Select(h => new { h.Competencias.Tp_Competencia, h.Dt_certificacao }),
                            Idiomas = c.Linguagens.Select(l => new { l.Idiomas.Tp_Idioma, l.Tp_Nivel })
                        };
            query = query.DistinctBy(c => c.Id);

            if (!string.IsNullOrEmpty(Nome))
                query = query.Where(c => c.Nm_Candidato == Nome);
            //if (!string.IsNullOrEmpty(CPF))
            //    query = query.Where(c => c.CPF == CPF);
            if (!string.IsNullOrEmpty(Telefone))
                query = query.Where(c => c.Nm_Telefone == Telefone);
            if (!string.IsNullOrEmpty(Email))
                query = query.Where(c => c.Email == Email);
            if (!string.IsNullOrEmpty(Idioma) && SomenteIdioma)
                query = query.Where(c => c.Tp_Idioma == Idioma);
            if (!string.IsNullOrEmpty(Skill) && SomenteSkill)
                query = query.Where(c => c.Tp_Tecnologias == Skill);
            if (!string.IsNullOrEmpty(Competencia) && SomenteCompetencia)
                query = query.Where(c => c.Tp_Competencia == Competencia);

            if (Idioma != null) {
                var idioma_int = (string i) => i == Idioma ? 1 : 0;
                var orderedQuery = query.OrderByDescending(c => idioma_int(c.Tp_Idioma));

                if (LinguagemNivelDesc != null) {
                    if (LinguagemNivelDesc.Value)
                        query = orderedQuery.ThenByDescending(c => (int)c.Tp_Nivel);
                    else
                        query = orderedQuery.ThenBy(c => c.Tp_Idioma);
                }
            } else {
                if (LinguagemNivelDesc != null) {
                    if (LinguagemNivelDesc.Value)
                        query = query.OrderByDescending(c => c.Tp_Nivel);
                    else
                        query = query.OrderBy(c => c.Tp_Nivel);
                }
            }
            int cont = query.Where(c => c.Tp_Idioma == Idioma).Count();
            if (Limite > 0)
                query = query.Take(Limite);

            return new object[] {
                query.Count(),
                query.Select(c => new {
                    c.Id,
                    c.Nm_Candidato,
                    c.Nm_Telefone,
                    c.Email,
                    c.Skills,
                    c.Habilidades,
                    c.Idiomas
                })
            };
        }
    }
}
