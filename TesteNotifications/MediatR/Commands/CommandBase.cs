using FluentValidation.Results;
using MediatR;

namespace TesteNotifications.MediatR.Commands
{
    public abstract class CommandBase : IRequest<bool>
    {
        public ValidationResult Validation { get; set; }
    }
}
