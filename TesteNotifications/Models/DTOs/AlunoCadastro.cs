using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TesteNotifications.Models.DTOs
{
    public class AlunoCadastro
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        
        [JsonProperty("sobrenome")]
        public string Sobrenome { get; set; }

        [JsonProperty("nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
    }
}
