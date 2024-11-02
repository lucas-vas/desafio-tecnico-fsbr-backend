namespace DesafioTecnicoFSBR.Domain.Exceptions
{
    public class DomainException(string messageThrow) : Exception(messageThrow)
    {
        public static void When(bool conditionThrow, string messageThrow)
        {
            if (conditionThrow)
                throw new DomainException(messageThrow);
        }
    }
}
