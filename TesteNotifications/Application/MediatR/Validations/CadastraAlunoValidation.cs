using FluentValidation;
using System;
using TesteNotifications.Application.MediatR.Commands;

namespace TesteNotifications.Application.MediatR.Validations
{
    public class CadastraAlunoValidation : AbstractValidator<CadastraAlunoCommand>
    {
        public CadastraAlunoValidation()
        {
            RuleFor(a => a.Nome)
               .NotEmpty()
               .WithName(a => nameof(a.Nome))
               .WithMessage("Nome do aluno é obrigatório!")
               .MaximumLength(25)
               .WithName(a => nameof(a.Nome))
               .WithMessage("Nome do aluno deve ter até 25 caracteres!");

            RuleFor(a => a.Sobrenome)
                .NotEmpty()
                .WithName(a => nameof(a.Sobrenome))
                .WithMessage("Sobrenome do aluno é obrigatório!")
                .MaximumLength(40)
                .WithName(a => nameof(a.Sobrenome))
                .WithMessage("Sobrenome do aluno deve ter até 40 caracteres!");

            RuleFor(a => a.Nascimento)
                .NotNull()
                .WithName(a => nameof(a.Nascimento))
                .WithMessage("Data de nascimento é obrigatória!");

            RuleFor(a => DateTime.Now.Year - a.Nascimento.Year)
                .GreaterThan(17)
                .WithName("Idade")
                .WithMessage("Aluno sem idade permitida!")
                .When(a => a.Nascimento != null);
        }
    }
}
