using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteNotifications.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public int Matricula { get; private set; }
        public DateTime Nascimento { get; private set; }

        public Aluno(string nome, string sobrenome, DateTime nascimento)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Sobrenome = sobrenome;
            Matricula = new Random().Next(16536456, 17873645);
            Nascimento = nascimento;
        }

        public int ObterIdade()
        {
            return DateTime.Now.Year - Nascimento.Year;
        }
    }
}
