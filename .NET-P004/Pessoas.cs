using System;
using System.Collections.Generic;
using Academias;

namespace Pessoas
{
    public class Pessoa
    {
        public string Nome { get; set; } = string.Empty;
        protected DateTime dataNascimento;
        public DateTime DataNascimento
        {
            get => dataNascimento;
            set
            {
                if (value < DateTime.Now)
                {
                    dataNascimento = value;
                }
                else
                {
                    throw new ArgumentException("Data de nascimento inválida.");
                }
            }
        }

        protected string cpf = string.Empty;
        protected static List<string> cpfs = new List<string>();

        public Pessoa()
        {
        }

        public string CPF
        {
            get => cpf;
            set
            {
                if (value.Length == 11 && !cpfs.Contains(value))
                {
                    cpf = value;
                    cpfs.Add(value);
                }
                else
                {
                    throw new ArgumentException("CPF inválido ou já existente.");
                }
            }
        }
    }

    public class Treinador : Pessoa
    {
        protected string cref = string.Empty;
        protected static List<string> crefs = new List<string>();

        public string CREF
        {
            get => cref;
            set
            {
                if (value.Length == 6 && !crefs.Contains(value))
                {
                    cref = value;
                    crefs.Add(value);
                }
                else
                {
                    throw new ArgumentException("CREF inválido ou já existente.");
                }
            }
        }
    }

    public class Cliente : Pessoa
    {
        protected double altura;
        public double Altura
        {
            get => altura;
            set
            {
                if (value >= 0)
                {
                    altura = value;
                }
                else
                {
                    throw new ArgumentException("Altura não pode ser negativa.");
                }
            }
        }
        
        protected double peso;
        public double Peso
        {
            get => peso;
            set
            {
                if (value >= 0)
                {
                    peso = value;
                }
                else
                {
                    throw new ArgumentException("Peso não pode ser negativo.");
                }
            }
        }
    }
}