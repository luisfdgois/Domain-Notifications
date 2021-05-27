using System;

namespace TesteNotifications.Domain.Models.ValueObjects
{
    public class AlunoVM
    {
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
