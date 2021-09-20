﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePraticoWevo.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Sexo { get; set; }
        public DateTime DtNascimento { get; set; }
        public int? TarefaId { get; set; }
    }
}
