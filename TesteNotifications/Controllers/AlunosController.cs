using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteNotifications.Application.MediatR.Commands;
using TesteNotifications.Domain.Contracts;
using TesteNotifications.Models.DTOs;

namespace TesteNotifications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IAlunoQueryRepository _queryRepository;

        public AlunosController(IMediator mediator, IMapper mapper, IAlunoQueryRepository queryRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _queryRepository = queryRepository;
        }

        [HttpGet]
        public IActionResult ListarAlunos(int pagAtual, int totalPorPag)
        {
            return Ok(_queryRepository.ListarAlunos(pagAtual, totalPorPag));
        }

        [HttpPost]
        public IActionResult AdicionarAluno(AlunoCadastro alunoCadastro)
        {
            var alunoCommand = _mapper.Map<CadastraAlunoCommand>(alunoCadastro);

            _mediator.Send(alunoCommand);

            return Ok("Aluno cadastrado com sucesso!");
        }
    }
}