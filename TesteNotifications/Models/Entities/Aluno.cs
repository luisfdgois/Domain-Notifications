using System;

namespace TesteNotifications.Models.Entities
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
