using BRQ_Rank.Db;

namespace BRQ_Rank.Filtros {
    public static class AlgoritmoBusca {
        public static object GetQuery(this DatabaseContext db, string Idioma = "", string Skill = "", string Competencia = "",
                                             bool SomenteSkill = false, bool SomenteCompetencia = false, bool SomenteIdioma = false,
                                             string Nome = ""/*, string CPF = ""*/, string Email = "", string Telefone = "",
                                             int Limite = 10) {
            if (Limite > 100)
                Limite = 100;

            var query = from c in db.Candidato
                        join l in db.Linguagem on c.Id equals l.Candidato.Id
                        join i in db.Idiomas on l.Idiomas.Id_idioma equals i.Id_idioma
                        join s in db.Skills on c.Id equals s.Candidato.Id
                        join t in db.Tecnologias on s.Tecnologias.Id_Tecnologias equals t.Id_Tecnologias
                        join h in db.Habilidade on c.Id equals h.Candidato.Id
                        join cp in db.Competencias on h.Competencias.Id equals cp.Id
                        orderby (Idioma != "" ? i.Tp_Idioma == Idioma : false) descending, (Idioma != "" ? l.Tp_Nivel : 0) descending,
                        (Skill != "" ? t.Tp_Tecnologias == Skill : false) descending,
                        (Competencia != "" ? cp.Tp_Competencia == Competencia : false) descending,
                        c.Linguagens.Count() descending, c.Skills.Count() descending, c.Habilidades.Count() descending
                        where (!string.IsNullOrEmpty(Nome) ? c.Nm_Candidato.ToLower().Contains(Nome.ToLower()) : true)
                        && (!string.IsNullOrEmpty(Telefone) ? c.Nm_Telefone.Contains(Telefone) : true)
                        && (!string.IsNullOrEmpty(Email) ? c.Nm_Email.ToLower() == Email.ToLower() : true)
                        && (!string.IsNullOrEmpty(Idioma) && SomenteIdioma ? i.Tp_Idioma.ToLower() == Idioma.ToLower() : true)
                        && (!string.IsNullOrEmpty(Skill) && SomenteSkill ? t.Tp_Tecnologias.ToLower() == Skill.ToLower() : true)
                        && (!string.IsNullOrEmpty(Competencia) && SomenteCompetencia ? cp.Tp_Competencia.ToLower() == Competencia.ToLower() : true)
                        select new {
                            c.Id,
                            c.Nm_Candidato,
                            c.Nm_Telefone,
                            c.Nm_Email,
                            l.Tp_Nivel,
                            i.Tp_Idioma,
                            s.Dt_Certificado,
                            t.Tp_Tecnologias,
                            h.Dt_certificacao,
                            cp.Tp_Competencia,
                            Skills = c.Skills.Select(s => new { s.Tecnologias.Tp_Tecnologias, s.Dt_Certificado }),
                            Habilidades = c.Habilidades.Select(h => new { h.Competencias.Tp_Competencia, h.Dt_certificacao }),
                            Idiomas = c.Linguagens.Select(l => new { l.Idiomas.Tp_Idioma, l.Tp_Nivel })
                        };

            var ret = query.ToList().DistinctBy(c => c.Id);
            if (Limite > 0)
                ret = ret.Take(Limite);
            return new object[] {
                ret.Count(),
                ret.Select(c => new {
                    c.Id,
                    c.Nm_Candidato,
                    c.Nm_Telefone,
                    c.Nm_Email,
                    c.Skills,
                    c.Habilidades,
                    c.Idiomas
                })
            };
        }
    }
}
