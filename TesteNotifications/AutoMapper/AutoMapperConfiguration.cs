using AutoMapper;
using TesteNotifications.MediatR.Commands;
using TesteNotifications.Models.DTOs;
using TesteNotifications.Models.Entities;
using TesteNotifications.Models.ViewModels;

namespace TesteNotifications.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<CadastraAlunoCommand, Aluno>();
            CreateMap<AlunoCadastro, Aluno>();
            CreateMap<AlunoCadastro, CadastraAlunoCommand>();
            CreateMap<Aluno, AlunoViewModel>();
        }
    }
}

