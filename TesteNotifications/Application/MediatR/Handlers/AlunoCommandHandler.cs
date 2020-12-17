using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteNotifications.Application.MediatR.Commands;
using TesteNotifications.Application.MediatR.Notifications;
using TesteNotifications.Domain.Contracts;
using TesteNotifications.Domain.Entities;

namespace TesteNotifications.Application.MediatR.Handlers
{
    public class AlunoCommandHandler : IRequestHandler<CadastraAlunoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly AlunoRepository _alunoRepository;

        public AlunoCommandHandler(IMediator mediator, IMapper mapper, AlunoRepository alunoRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _alunoRepository = alunoRepository;
        }

        public Task<bool> Handle(CadastraAlunoCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var aluno = _mapper.Map<Aluno>(request);

                _alunoRepository.Adicionar(aluno);

                return Task.FromResult(_alunoRepository.Commit());
            }

            _mediator.Publish(new ErrorNotification { Validations = request.Validation.Errors });

            return Task.FromResult(false);
        }
    }
}
