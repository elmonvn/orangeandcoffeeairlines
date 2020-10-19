using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCAirLines.WebAPI.Models
{
    public class UsuarioModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string TpIdentificacao { get; set; }
        public string NrIdentificacao { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public bool Status { get; set; }
    }
}
