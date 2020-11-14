using System;
using System.Collections.Generic;
using System.Linq;
using TesteNotifications.Models.Entities;

namespace TesteNotifications.Data.Repositories
{
    public class RepositoryAlunoImp : RepositoryAluno
    {
        private ICollection<Aluno> _alunos;

        public RepositoryAlunoImp()
        {
            _alunos = new List<Aluno>();
        }

        public void Adicionar(Aluno aluno)
        {
            _alunos.Add(aluno);
        }

        public ICollection<Aluno> ObterTodos()
        {
            return _alunos;
        }

        public Aluno ObterPorId(Guid alunoId)
        {
            return _alunos.Where(a => a.Id.Equals(alunoId)).FirstOrDefault();
        }

        public Aluno ObterPorMatricula(int matricula)
        {
            return _alunos.Where(a => a.Matricula == matricula).FirstOrDefault();
        }
    }
}
