using System;
using TesteNotifications.MediatR.Validations;

namespace TesteNotifications.MediatR.Commands
{
    public class CadastraAlunoCommand : CommandBase
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime Nascimento { get; private set; }

        public CadastraAlunoCommand(string nome, string sobrenome, DateTime nascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
        }

        public bool IsValid()
        {
            Validation = new CadastraAlunoValidation().Validate(this);
            return Validation.IsValid;
        }
    }
}
