﻿namespace BRQ_Rank.Models {
    public class Competencias {
        public int Id { get; set; }
        public string? Tp_Competencia { get; set; }

        public Competencias() {

        }

        public Competencias(string? tp_Competencia) {
            Tp_Competencia = tp_Competencia;
        }
    }
}
