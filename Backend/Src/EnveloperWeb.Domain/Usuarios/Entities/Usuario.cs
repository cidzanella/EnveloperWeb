﻿namespace EnveloperWeb.Domain.Usuarios.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; } // Ex: Admin, Operador
    }
}
