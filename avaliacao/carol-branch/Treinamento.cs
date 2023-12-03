using System;
using System.Collections.Generic;
using Pessoas;
namespace Treinamento
{
    class Exercicio
    {
        public string GrupoMuscular { get; set; }
        public int Series { get; set; }
        public int Repeticoes { get; set; }
        public int TempoIntervaloSegundos { get; set; }
    }

    class Treino
    {
        public string Tipo { get; set; }
        public string Objetivo { get; set; }
        public List<Exercicio> ListaExercicios { get; set; }
        public int DuracaoEstimadaMinutos { get; set; }
        public DateTime DataInicio { get; set; }
        public int VencimentoDias { get; set; }
    }
}