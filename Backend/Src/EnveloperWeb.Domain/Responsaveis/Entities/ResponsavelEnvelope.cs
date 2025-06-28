using EnveloperWeb.Domain.Envelopes.Entities;
using EnveloperWeb.Domain.Usuarios.Entities;

namespace EnveloperWeb.Domain.Responsaveis.Entities
{
    public class ResponsavelEnvelope
    {
        public int EnvelopeId { get; set; }
        public Envelope Envelope { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
