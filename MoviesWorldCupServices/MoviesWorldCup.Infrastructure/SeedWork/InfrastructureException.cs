using System;
using System.Runtime.Serialization;

namespace MoviesWorldCup.Infrastructure.SeedWork
{
    [Serializable]
    public class InfrastructureException: Exception
    {
        public InfrastructureException(Exception innerException)
            : base("Houve um erro na camada de infraestrutura, verifique a exceção interna para obter mais informações", innerException)
        {
        }
        public InfrastructureException(string msg, Exception innerException)
            : base($"Houve um erro na camada de infraestrutura. {msg}", innerException)
        {
        }

        protected InfrastructureException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
