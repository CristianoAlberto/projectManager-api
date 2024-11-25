using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagerApi.src.Infrastructure.Config
{
    public class Jwtconfig
    {
        public required string Secret { get; set; } // Chave secreta para assinatura do JWT
        public required int ExpiryMinutes { get; set; } // Tempo de expiração do token
        public required string Issuer { get; set; } // Emissor do token (quem gerou)
        public required string Audience { get; set; }
    }
}