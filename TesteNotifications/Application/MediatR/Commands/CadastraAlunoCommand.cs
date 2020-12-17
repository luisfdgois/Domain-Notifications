using FluentValidation.Results;
using MediatR;
using System;
using TesteNotifications.Application.MediatR.Validations;

namespace TesteNotifications.Application.MediatR.Commands
{
    public class CadastraAlunoCommand : IRequest<bool>
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime Nascimento { get; private set; }

        public ValidationResult Validation { get; private set; }

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
