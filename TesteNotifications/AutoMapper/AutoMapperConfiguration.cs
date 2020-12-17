using AutoMapper;
using TesteNotifications.Application.MediatR.Commands;
using TesteNotifications.Domain.Entities;
using TesteNotifications.Models.DTOs;

namespace TesteNotifications.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            CreateMap<CadastraAlunoCommand, Aluno>();
            CreateMap<AlunoCadastro, CadastraAlunoCommand>();
        }
    }
}

