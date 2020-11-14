using Newtonsoft.Json;
using System;

namespace TesteNotifications.Models.DTOs
{
    public class AlunoCadastro
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        
        [JsonProperty("sobrenome")]
        public string Sobrenome { get; set; }

        [JsonProperty("nascimento")]
        public DateTime Nascimento { get; set; }
    }
}
