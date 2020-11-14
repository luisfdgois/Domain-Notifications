using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TesteNotifications.Data.Repositories;
using TesteNotifications.MediatR.Commands;
using TesteNotifications.MediatR.Notifications;
using TesteNotifications.Models.Entities;

namespace TesteNotifications.MediatR.Handlers
{
    public class AlunoCommandHandler : IRequestHandler<CadastraAlunoCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RepositoryAluno _repositoryAluno;

        public AlunoCommandHandler(IMediator mediator, IMapper mapper, RepositoryAluno repositoryAluno)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repositoryAluno = repositoryAluno;
        }

        public Task<bool> Handle(CadastraAlunoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                _mediator.Publish(new DomainNotification(request.Validation));
                return Task.FromResult(false);
            }

            var aluno = _mapper.Map<Aluno>(request);
            _repositoryAluno.Adicionar(aluno);

            return Task.FromResult(true);
        }
    }
}
