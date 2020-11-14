using AutoMapper;
using System.Collections.Generic;
using TesteNotifications.Data.Repositories;
using TesteNotifications.Models.ViewModels;

namespace TesteNotifications.Querys
{
    public class RepositoryQueryImp : RepositoryQuery
    {
        private readonly RepositoryAluno _repositoryAluno;
        private IMapper _mapper;

        public RepositoryQueryImp(RepositoryAluno repositoryAluno, IMapper mapper)
        {
            _repositoryAluno = repositoryAluno;
            _mapper = mapper;
        }

        public ICollection<AlunoViewModel> ListarAlunos()
        {
            return _mapper.Map<ICollection<AlunoViewModel>>(_repositoryAluno.ObterTodos());
        }
    }
}
