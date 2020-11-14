using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteNotifications.MediatR.Commands;
using TesteNotifications.Models.DTOs;
using TesteNotifications.Querys;

namespace TesteNotifications.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RepositoryQuery _repositoryQuery;

        public WeatherForecastController(IMediator mediator, IMapper mapper, RepositoryQuery repositoryQuery)
        {
            _mediator = mediator;
            _mapper = mapper;
            _repositoryQuery = repositoryQuery;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryQuery.ListarAlunos());
        }

        [HttpPost]
        public IActionResult Post(AlunoCadastro alunoCadastro)
        {
            var alunoCommand = _mapper.Map<CadastraAlunoCommand>(alunoCadastro);

            _mediator.Send(alunoCommand);

            return Ok("Aluno cadastrado com sucesso!");
        }
    }
}