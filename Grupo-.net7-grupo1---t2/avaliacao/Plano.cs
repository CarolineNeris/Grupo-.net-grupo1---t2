using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Planos
{
    public class Plano
    {
        public string Titulo { get; set; }
        public double ValorPorMes { get; set; }

        public Plano(string titulo, double valorPorMes)
        {
            Titulo = titulo;
            ValorPorMes = valorPorMes;
        }
    }
    
}